using System.Collections.Generic;
using System.Threading.Tasks;
using Pitstop.Models;
using Microsoft.AspNetCore.Hosting;
using Refit;
using WebApp.Commands;
using System.Net;
using Pitstop.Application.VehicleManagement.Model;

namespace WebApp.RESTClients
{
    public class VehicleManagementAPI : IVehicleManagementAPI
    {
        private IVehicleManagementAPI _client;

        public  VehicleManagementAPI(IHostingEnvironment env)
        {
            string apiHost = env.IsDevelopment() ? "localhost" : "apigateway";
            int apiPort = 10000;
            string baseUri = $"http://{apiHost}:{apiPort}/api";
            _client = RestService.For<IVehicleManagementAPI>(baseUri);
        }

        #region Vehicles

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _client.GetVehicles();
        }

        public async Task<Vehicle> GetVehicleByCode([AliasAs("id")] string codigo)
        {
            try
            {
                return await _client.GetVehicleByCode(codigo);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task RegisterVehicle(RegisterVehicle command)
        {
            await _client.RegisterVehicle(command);
        }

        #endregion

        #region Owners

        public async Task<List<Owner>> GetOwners()
        {
            return await _client.GetOwners();
        }

        public async Task<Owner> GetOwnerById([AliasAs("id")] int ownerId)
        {
            try
            {
                return await _client.GetOwnerById(ownerId);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task RegisterOwner(RegisterOwner command)
        {
            await _client.RegisterOwner(command);
        }

        #endregion

        #region Insurance       

        public async Task<List<Insurance>> GetInsurances()
        {
            return await _client.GetInsurances();
        }

        public async Task<Insurance> GeInsuranceById([AliasAs("id")] int insuranceId)
        {
            try
            {
                return await _client.GeInsuranceById(insuranceId);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task RegisterInsurance(RegisterInsurance command)
        {
            await _client.RegisterInsurance(command);
        }

        #endregion
    }
}
