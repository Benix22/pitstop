using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pitstop.Models;
using Pitstop.ViewModels.ContractManagement;
using System.Threading.Tasks;
using WebApp.Commands;
using WebApp.RESTClients;

namespace PitStop.Controllers
{
    public class RateManagementController : Controller
    {
        private readonly IContractManagementAPI _contractManagementAPI;
        private readonly ILogger _logger;
        private ResiliencyHelper _resiliencyHelper;

        public RateManagementController(IContractManagementAPI contractManagementAPI, ILogger<RateManagementController> logger)
        {
            _contractManagementAPI = contractManagementAPI;
            _logger = logger;
            _resiliencyHelper = new ResiliencyHelper(_logger);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                var model = new ContractManagementViewModel
                {
                    Rates = await _contractManagementAPI.GetRates()
                };
                return View(model);
            }, View("Offline", new ContractManagementOfflineViewModel()));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                var model = new ContractManagementDetailsViewModel
                {
                    Rate = await _contractManagementAPI.GetByRateId(id)
                };
                return View(model);
            }, View("Offline", new ContractManagementOfflineViewModel()));
        }

        [HttpGet]
        public IActionResult New()
        {
            var model = new ContractManagementNewViewModel
            {
                Rate = new Rate()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] ContractManagementNewViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                return await _resiliencyHelper.ExecuteResilient(async () =>
                {
                    RegisterRate cmd = Mapper.Map<RegisterRate>(inputModel.Rate);
                    await _contractManagementAPI.RegisterRate(cmd);
                    return RedirectToAction("Index");
                }, View("Offline", new ContractManagementOfflineViewModel()));
            }
            else
            {
                return View("New", inputModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] ContractManagementNewViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                return await _resiliencyHelper.ExecuteResilient(async () =>
                {
                    RegisterRate cmd = Mapper.Map<RegisterRate>(inputModel.Rate);
                    await _contractManagementAPI.UpdateRate(cmd);
                    return RedirectToAction("Index");
                }, View("Offline", new ContractManagementOfflineViewModel()));
            }
            else
            {
                return View("New", inputModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
                await _contractManagementAPI.DeleteRate(id);
                return RedirectToAction("Index");
        }
    }
}