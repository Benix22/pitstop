using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pitstop.Models;
using Pitstop.ViewModels;
using AutoMapper;
using Polly;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Commands;
using WebApp.RESTClients;
using Pitstop.Application.VehicleManagement.Model;

namespace PitStop.Controllers
{
    public class VehicleOwnerManagementController : Controller
    {
        private IVehicleManagementAPI _vehicleManagementAPI;
        private ICustomerManagementAPI _customerManagementAPI;
        private readonly ILogger _logger;
        private ResiliencyHelper _resiliencyHelper;

        public VehicleOwnerManagementController(IVehicleManagementAPI vehicleManagementAPI, 
            ICustomerManagementAPI customerManagementAPI, ILogger<VehicleManagementController> logger)
        {
            _vehicleManagementAPI = vehicleManagementAPI;
            _logger = logger;
            _resiliencyHelper = new ResiliencyHelper(_logger);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                var model = new VehicleOwnerManagementViewModel
                {
                    Owners = await _vehicleManagementAPI.GetOwners()
                };
                return View(model);
            }, View("Offline", new VehicleOwnerManagementOfflineViewModel()));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                Owner owner = await _vehicleManagementAPI.GetOwnerById(id);

                var model = new VehicleOwnerManagementDetailsViewModel
                {
                    Owner = owner
                };
                return View(model);
            }, View("Offline", new VehicleOwnerManagementOfflineViewModel()));
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                var model = new VehicleOwnerManagementNewViewModel
                {
                    Owner = new Owner()
                };
                return View(model);
            }, View("Offline", new VehicleOwnerManagementOfflineViewModel()));
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] VehicleOwnerManagementNewViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                return await _resiliencyHelper.ExecuteResilient(async () =>
                {
                    RegisterOwner cmd = Mapper.Map<RegisterOwner>(inputModel);
                    await _vehicleManagementAPI.RegisterOwner(cmd);
                    return RedirectToAction("Index");
                }, View("Offline", new VehicleOwnerManagementOfflineViewModel()));
            }
            else
            {
                return View("New", inputModel);
            }
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
    }
}
