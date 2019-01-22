using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Pitstop.Models;
using Refit;
using WebApp.Commands;

namespace WebApp.RESTClients
{
    public class ContractManagementAPI : IContractManagementAPI
    {
        private IContractManagementAPI _client;

        public ContractManagementAPI(IHostingEnvironment env)
        {
            string apiHost = env.IsDevelopment() ? "localhost" : "apigateway";
            int apiPort = 10000;
            string baseUri = $"http://{apiHost}:{apiPort}/api";
            _client = RestService.For<IContractManagementAPI>(baseUri);
        }

        public async Task<List<Rate>> GetRates()
        {
            return await _client.GetRates();
        }

        public async Task<Rate> GetByRateId([AliasAs("id")] int rateId)
        {
            try
            {
                return await _client.GetByRateId(rateId);
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

        public async Task RegisterRate(RegisterRate command)
        {
            try
            {
                await _client.RegisterRate(command);
            }
            catch (System.Exception e)
            {
                throw e.InnerException;
            }
        }
    }
}
