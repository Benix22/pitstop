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
    public class VatManagementController : Controller
    {
        private readonly IContractManagementAPI _contractManagementAPI;
        private readonly ILogger _logger;
        private ResiliencyHelper _resiliencyHelper;

        public VatManagementController(IContractManagementAPI contractManagementAPI, ILogger<RateManagementController> logger)
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
                    Vats = await _contractManagementAPI.GetVats()
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
                    Vat = await _contractManagementAPI.GetByVatId(id)
                };
                return View(model);
            }, View("Offline", new ContractManagementOfflineViewModel()));
        }

        [HttpGet]
        public IActionResult New()
        {
            var model = new ContractManagementNewViewModel
            {
                Vat = new VAT()
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
                    RegisterVat cmd = Mapper.Map<RegisterVat>(inputModel.Vat);
                    await _contractManagementAPI.RegisterVat(cmd);
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
                    RegisterVat cmd = Mapper.Map<RegisterVat>(inputModel.Vat);
                    await _contractManagementAPI.UpdateVat(cmd);
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
                await _contractManagementAPI.DeleteVat(id);
                return RedirectToAction("Index");
        }
    }
}