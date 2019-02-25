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
    [ApiController]
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
                    insurance.Matricula = _dbContext.Vehicles.FirstOrDefaultAsync(x => x.Codigo == insurance.VehicleId).Result.Matricula;
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
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            var insurance = await _dbContext.Insurances.FirstOrDefaultAsync(c => c.InsuranceId == id);
            if (insurance != null)
            {
                _dbContext.Insurances.Remove(insurance);
                await _dbContext.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
