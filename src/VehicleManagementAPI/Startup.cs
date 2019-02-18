using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Pitstop.Application.VehicleManagement.Commands;
using Pitstop.Application.VehicleManagement.DataAccess;
using Pitstop.Application.VehicleManagement.Events;
using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Application.VehicleOwnerManagement.Commands;
using Pitstop.Infrastructure.Messaging;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Pitstop.VehicleManagement
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add DBContext classes
            var sqlConnectionString = Configuration.GetConnectionString("VehicleManagementCN");
            services.AddDbContext<VehicleManagementDBContext>(options => options.UseSqlServer(sqlConnectionString));

            // add messagepublisher classes
            var configSection = Configuration.GetSection("RabbitMQ");
            string host = configSection["Host"];
            string userName = configSection["UserName"];
            string password = configSection["Password"];
            services.AddTransient<IMessagePublisher>((sp) => new RabbitMQMessagePublisher(host, userName, password, "Pitstop"));

            // Add framework services.
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options
                        .SuppressModelStateInvalidFilter = true;
                    options
                      .SuppressUseValidationProblemDetailsForInvalidModelStateResponses = true;                    
                });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "VehicleManagement API", Version = "v1" });
            });

            services.AddHealthChecks(checks =>
            {
                checks.WithDefaultCacheDuration(TimeSpan.FromSeconds(1));
                checks.AddSqlCheck("VehicleManagementCN", Configuration.GetConnectionString("VehicleManagementCN"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            SetupAutoMapper();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehicleManagement API - v1");
            });

            app.UseDeveloperExceptionPage();

        }

        private void SetupAutoMapper()
        {
            // setup automapper
            Mapper.Initialize(cfg =>
            {
                try
                {
                    cfg.CreateMap<Vehicle, RegisterVehicle>()
                            .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));
                    cfg.CreateMap<RegisterVehicle, VehicleRegistered>()
                        .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));

                    cfg.CreateMap<Owner, RegisterOwner>()
                     .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));
                    cfg.CreateMap<RegisterOwner, OwnerRegistered>()
                        .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));

                    cfg.CreateMap<Insurance, RegisterInsurance>()
                     .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));
                    cfg.CreateMap<RegisterInsurance, InsuranceRegistered>()
                        .ForCtorParam("messageId", opt => opt.MapFrom(c => Guid.NewGuid()));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
    }
}
