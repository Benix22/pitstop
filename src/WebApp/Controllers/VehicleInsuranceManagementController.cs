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
    public class VehicleInsuranceManagement : Controller
    {
        private IVehicleManagementAPI _vehicleManagementAPI;
        private readonly ILogger _logger;
        private ResiliencyHelper _resiliencyHelper;

        public VehicleInsuranceManagement(IVehicleManagementAPI vehicleManagementAPI, 
            ILogger<VehicleInsuranceManagement> logger)
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
                var model = new VehicleInsuranceManagementViewModel
                {
                    Insurances = await _vehicleManagementAPI.GetInsurances()
                };
                return View(model);
            }, View("Offline", new VehicleInsuranceManagementOfflineViewModel()));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                var insurance = await _vehicleManagementAPI.GeInsuranceById(id);

                var vehicle = await _vehicleManagementAPI.GetVehicleByCode(insurance.VehicleId.ToString());

                var model = new VehicleInsuranceManagementDetailsViewModel
                {
                    Insurance = insurance,
                    Vehicle = vehicle
                };
                return View(model);
            }, View("Offline", new VehicleInsuranceManagementOfflineViewModel()));
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                //get vehiclelist
                var vehicles = await _vehicleManagementAPI.GetVehicles();

                var model = new VehicleInsuranceManagementNewViewModel
                {
                    Insurance = new Insurance(),
                    Vehicles = vehicles.Select(c => new SelectListItem { Value = c.Codigo.ToString(), Text = c.Matricula })
                };
                return View(model);
            }, View("Offline", new VehicleInsuranceManagementOfflineViewModel()));
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] VehicleInsuranceManagementNewViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                return await _resiliencyHelper.ExecuteResilient(async () =>
                {
                    RegisterInsurance cmd = Mapper.Map<RegisterInsurance>(inputModel.Insurance);
                    await _vehicleManagementAPI.RegisterInsurance(cmd);
                    return RedirectToAction("Index");
                }, View("Offline", new VehicleInsuranceManagementOfflineViewModel()));
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
