using Pitstop.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Commands;

namespace WebApp.RESTClients
{
    public interface ICustomerManagementAPI
    {
        [Get("/customers")]
        Task<List<Customer>> GetCustomers();

        [Get("/customers/{id}")]
        Task<Customer> GetCustomerById([AliasAs("id")] Guid customerId);

        [Post("/customers")]
        Task RegisterCustomer(RegisterCustomer command);

        [Put("/customers")]
        Task UpdateCustomer(RegisterCustomer command);

        [Delete("/customers/{id}")]
        Task<List<Customer>> DeleteCustomer([AliasAs("id")] string customerId);
    }
}
