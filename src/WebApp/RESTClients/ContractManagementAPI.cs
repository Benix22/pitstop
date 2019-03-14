using Microsoft.AspNetCore.Hosting;
using Pitstop.Models;
using Refit;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApp.Commands;
using Microsoft.Extensions.Configuration;

namespace WebApp.RESTClients
{
    public class ContractManagementAPI : IContractManagementAPI
    {
        private IContractManagementAPI _client;

        public ContractManagementAPI(IConfiguration config)
        {
            string apiHostAndPort = config.GetSection("APIServiceLocations").GetValue<string>("ContractManagementAPI");
            string baseUri = $"http://{apiHostAndPort}/api";
            _client = RestService.For<IContractManagementAPI>(baseUri);
        }

        #region Rates
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

        public async Task UpdateRate(RegisterRate command)
        {
            try
            {
                await _client.UpdateRate(command);
            }
            catch (System.Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task<List<Rate>> DeleteRate(int rateId)
        {
            return await _client.DeleteRate(rateId);
        }

        #endregion

        #region Vats

        public async Task<List<VAT>> GetVats()
        {
            return await _client.GetVats();
        }

        public async Task<VAT> GetByVatId([AliasAs("id")] int vatId)
        {
            try
            {
                return await _client.GetByVatId(vatId);
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

        public async Task RegisterVat(RegisterVat command)
        {
            try
            {
                await _client.RegisterVat(command);
            }
            catch (System.Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task UpdateVat(RegisterVat command)
        {
            try
            {
                await _client.UpdateVat(command);
            }
            catch (System.Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task<List<VAT>> DeleteVat(int vatId)
        {
            return await _client.DeleteVat(vatId);
        }

        #endregion
    }
}
