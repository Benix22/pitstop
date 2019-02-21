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

        [Delete("/vehicles/{id}")]
        Task<List<Vehicle>> DeleteVehicle([AliasAs("id")] int id);

        [Get("/owners")]
        Task<List<Owner>> GetOwners();

        [Get("/owners/{id}")]
        Task<Owner> GetOwnerById([AliasAs("id")] int ownerId);

        [Post("/owners")]
        Task RegisterOwner(RegisterOwner command);

        [Delete("/owners/{id}")]
        Task<List<Owner>> DeleteOwner([AliasAs("id")] int id);

        [Get("/insurances")]
        Task<List<Insurance>> GetInsurances();

        [Get("/insurances/{id}")]
        Task<Insurance> GeInsuranceById([AliasAs("id")] int insuranceId);

        [Post("/insurances")]
        Task RegisterInsurance(RegisterInsurance command);

        [Delete("/insurances/{id}")]
        Task<List<Insurance>> DeleteInsurance([AliasAs("id")] int id);


    }
}
