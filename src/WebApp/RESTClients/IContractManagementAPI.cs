using Pitstop.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Commands;

namespace WebApp.RESTClients
{
    public interface IContractManagementAPI
    {
        [Get("/rates")]
        Task<List<Rate>> GetRates();

        [Get("/rates/{id}")]
        Task<Rate> GetByRateId([AliasAs("id")] int rateId);

        [Post("/rates")]
        Task RegisterRate(RegisterRate command);

        [Delete("/rates/{id}")]
        Task<List<Rate>> DeleteRate([AliasAs("id")] int rateId);
    }
}
