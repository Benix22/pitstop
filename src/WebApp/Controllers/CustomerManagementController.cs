using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pitstop.Models;
using Pitstop.ViewModels;
using PitStop.Controllers;
using Polly;
using System;
using System.Threading.Tasks;
using WebApp.Commands;
using WebApp.RESTClients;

namespace PitStop.Controllers
{
    public class CustomerManagementController : Controller
    {
        private readonly ICustomerManagementAPI _customerManagementAPI;
        private readonly ILogger _logger;
        private ResiliencyHelper _resiliencyHelper;

        public CustomerManagementController(ICustomerManagementAPI customerManagementAPI, ILogger<CustomerManagementController> logger)
        {
            _customerManagementAPI = customerManagementAPI;
            _logger = logger;
            _resiliencyHelper = new ResiliencyHelper(_logger);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                var model = new CustomerManagementViewModel
                {
                    Customers = await _customerManagementAPI.GetCustomers()
                };
                return View(model);
            }, View("Offline", new CustomerManagementOfflineViewModel()));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                var model = new CustomerManagementDetailsViewModel
                {
                    Customer = await _customerManagementAPI.GetCustomerById(id)
                };
                return View(model);
            }, View("Offline", new CustomerManagementOfflineViewModel()));
        }

        [HttpGet]
        public IActionResult New()
        {
            var model = new CustomerManagementNewViewModel
            {
                Customer = new Customer()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] CustomerManagementNewViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                return await _resiliencyHelper.ExecuteResilient(async () =>
                {
                    //RegisterCustomer cmd = Mapper.Map<RegisterCustomer>(inputModel.Customer);
                    RegisterCustomer cmd = new RegisterCustomer(new Guid(),
                        inputModel.Customer.CustomerId,
                        inputModel.Customer.EsPersona,
                        inputModel.Customer.Nombre,
                        inputModel.Customer.Pais,
                        inputModel.Customer.NIF,
                        inputModel.Customer.FechaAlta,
                        inputModel.Customer.FechaBaja,
                        inputModel.Customer.Direccion,
                        inputModel.Customer.PaisDireccion,
                        inputModel.Customer.CodigoPostal,
                        inputModel.Customer.Poblacion,
                        inputModel.Customer.Provincia,
                        inputModel.Customer.Telefono,
                        inputModel.Customer.Telefono2,
                        inputModel.Customer.Movil,
                        inputModel.Customer.FechaExpNIF,
                        inputModel.Customer.PoblacionExpNIF,
                        inputModel.Customer.FechaNacimiento,
                        inputModel.Customer.PoblacionNacimiento,
                        inputModel.Customer.TipoPermiso,
                        inputModel.Customer.NumeroPermiso,
                        inputModel.Customer.FechaExpPermiso,
                        inputModel.Customer.FechaCadPermiso,
                        inputModel.Customer.Email,
                        inputModel.Customer.Bloqueado,
                        inputModel.Customer.Moroso,
                        inputModel.Customer.NumeroTarjetaCred,
                        inputModel.Customer.TitularTarjetaCred,
                        inputModel.Customer.FechaCadTarjetaCred
                        );
                    await _customerManagementAPI.RegisterCustomer(cmd);
                    return RedirectToAction("Index");
                }, View("Offline", new CustomerManagementOfflineViewModel()));
            }
            else
            {
                return View("New", inputModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _customerManagementAPI.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
