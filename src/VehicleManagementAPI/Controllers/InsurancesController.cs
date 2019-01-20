using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pitstop.Application.VehicleManagement.Commands;
using Pitstop.Application.VehicleManagement.DataAccess;
using Pitstop.Application.VehicleManagement.Events;
using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Infrastructure.Messaging;
using System;
using System.Threading.Tasks;

namespace Pitstop.Application.VehicleManagement.Controllers
{
    [Route("/api/[controller]")]
    public class InsurancesController : Controller
    {
        IMessagePublisher _messagePublisher;
        VehicleManagementDBContext _dbContext;

        public InsurancesController(VehicleManagementDBContext dbContext, IMessagePublisher messagePublisher)
        {
            _dbContext = dbContext;
            _messagePublisher = messagePublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var items = await _dbContext.Insurances.ToListAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("{insuranceId}", Name = "GetInsuranceById")]
        public async Task<IActionResult> GetInsuranceById(int insuranceId)
        {
            var insurance = await _dbContext.Insurances.FirstOrDefaultAsync(v => v.InsuranceId == insuranceId);
            if (insurance == null)
            {
                return NotFound();
            }
            return Ok(insurance);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterInsurance command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // insert insurance
                    Insurance insurance = Mapper.Map<Insurance>(command);
                    _dbContext.Insurances.Add(insurance);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    //var e = Mapper.Map<InsuranceRegistered>(command);
                    //await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                    //return result
                    return CreatedAtRoute("GetInsuranceById", new { insuranceId = insurance.InsuranceId }, insurance);
                }
                return BadRequest();
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
