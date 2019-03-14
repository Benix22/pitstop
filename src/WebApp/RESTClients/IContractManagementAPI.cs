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

        [Put("/rates")]
        Task UpdateRate(RegisterRate command);

        [Delete("/rates/{id}")]
        Task<List<Rate>> DeleteRate([AliasAs("id")] int rateId);

        [Get("/vats")]
        Task<List<VAT>> GetVats();

        [Get("/vats/{id}")]
        Task<VAT> GetByVatId([AliasAs("id")] int vatId);

        [Post("/vats")]
        Task RegisterVat(RegisterVat command);

        [Put("/vats")]
        Task UpdateVat(RegisterVat command);

        [Delete("/vats/{id}")]
        Task<List<VAT>> DeleteVat([AliasAs("id")] int vatId);
    }
}
