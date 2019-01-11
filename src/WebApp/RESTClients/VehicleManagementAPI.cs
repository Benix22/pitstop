﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Pitstop.Models;
using Microsoft.AspNetCore.Hosting;
using Refit;
using WebApp.Commands;
using System.Net;

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
    }
}
