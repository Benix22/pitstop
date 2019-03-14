using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Models;
using Pitstop.ViewModels;
using Serilog;
using System;
using System.Threading.Tasks;
using WebApp.Commands;
using WebApp.RESTClients;

namespace PitStop
{
    public class Startup
    {
        private IHostingEnvironment CurrentEnvironment { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
            CurrentEnvironment = env;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options
                        .SuppressModelStateInvalidFilter = true;
                    options
                      .SuppressUseValidationProblemDetailsForInvalidModelStateResponses = true;
                });

            // add custom services
            services.AddScoped<IContractManagementAPI, ContractManagementAPI>();
            services.AddScoped<ICustomerManagementAPI, CustomerManagementAPI>();
            services.AddScoped<IVehicleManagementAPI, VehicleManagementAPI>();
            services.AddScoped<IWorkshopManagementAPI, WorkshopManagementAPI>();
            
            services.AddHealthChecks(checks =>
            {
                checks.WithDefaultCacheDuration(TimeSpan.FromSeconds(1));
                checks.AddValueTaskCheck("HTTP Endpoint", () => new
                    ValueTask<IHealthCheckResult>(HealthCheckResult.Healthy("Ok")));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            SetupAutoMapper();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void SetupAutoMapper()
        {
            // setup automapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VAT, RegisterVat>()
                   .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));

                cfg.CreateMap<Rate, RegisterRate>()
                    .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));

                cfg.CreateMap<Customer, RegisterCustomer>()
                    .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));

                cfg.CreateMap<Vehicle, RegisterVehicle>()
                    .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));

                cfg.CreateMap<Owner,RegisterOwner>()
                    .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));

                cfg.CreateMap<Insurance, RegisterInsurance>()
                    .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));

                cfg.CreateMap<VehicleInsuranceManagementNewViewModel, RegisterInsurance>().ConvertUsing((vi, ri) =>
                new RegisterInsurance(Guid.NewGuid(), vi.Insurance.InsuranceId, vi.Insurance.Nombre, vi.Insurance.Poliza, vi.Insurance.Corredor,
                vi.Insurance.FechaAlta, vi.Insurance.FechaVencimiento, vi.Insurance.Importe, vi.Insurance.Tipo, vi.Insurance.VehicleId,vi.Insurance.Matricula));

                cfg.CreateMap<VehicleManagementNewViewModel, RegisterVehicle>().ConvertUsing((vm, rv) =>
                    new RegisterVehicle(Guid.NewGuid(), vm.Vehicle.Codigo, vm.Vehicle.OwnerId, vm.Vehicle.Matricula,
                    vm.Vehicle.Marca, vm.Vehicle.Modelo, vm.Vehicle.Color, vm.Vehicle.Bastidor, vm.Vehicle.Grupo, vm.Vehicle.Daños,
                    vm.Vehicle.Extras, vm.Vehicle.Observaciones, vm.Vehicle.Aviso, vm.Vehicle.PrimerDiaFlota, vm.Vehicle.DevolucionPrevista,
                    vm.Vehicle.UltimoDiaFlota, vm.Vehicle.FechaFabricacion, vm.Vehicle.FechaMatriculacion, vm.Vehicle.Km,
                    vm.Vehicle.Combustible, vm.Vehicle.DepositoLitros, vm.Vehicle.Plazas, vm.Vehicle.Puertas));
            });
        }
    }
}
