using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Commands;

namespace WebApp.RESTClients
{
    public interface IVehicleManagementAPI
    {
        [Get("/vehicles")]
        Task<List<Vehicle>> GetVehicles();

        [Get("/vehicles/{id}")]
        Task<Vehicle> GetVehicleByCode([AliasAs("id")] string codigo);

        [Post("/vehicles")]
        Task RegisterVehicle(RegisterVehicle command);

        [Get("/owners")]
        Task<List<Owner>> GetOwners();

        [Get("/owners/{id}")]
        Task<Owner> GetOwnerById([AliasAs("id")] int ownerId);

        [Post("/owners")]
        Task RegisterOwner(RegisterOwner command);
    }
}
