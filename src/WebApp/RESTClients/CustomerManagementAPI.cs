using System.Collections.Generic;
using System.Threading.Tasks;
using Pitstop.Models;
using Microsoft.AspNetCore.Hosting;
using Refit;
using WebApp.Commands;
using System.Net;
using System;

namespace WebApp.RESTClients
{
    public class CustomerManagementAPI : ICustomerManagementAPI
    {
        private ICustomerManagementAPI _client;

        public  CustomerManagementAPI(IHostingEnvironment env)
        {
            string apiHost = env.IsDevelopment() ? "localhost" : "apigateway";
            int apiPort = 10000;
            string baseUri = $"http://{apiHost}:{apiPort}/api";
            _client = RestService.For<ICustomerManagementAPI>(baseUri);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _client.GetCustomers();
        }

        public async Task<Customer> GetCustomerById([AliasAs("id")] Guid customerId)
        {
            try
            {
                return await _client.GetCustomerById(customerId);
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

        public async Task RegisterCustomer(RegisterCustomer command)
        {
            try
            {
                await _client.RegisterCustomer(command);
            }
            catch (System.Exception e)
            {
                throw e.InnerException;
            }
        }
    }
}
