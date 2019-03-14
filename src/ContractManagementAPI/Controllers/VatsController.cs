using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pitstop.ContractManagementAPI.Commands;
using Pitstop.ContractManagementAPI.DataAccess;
using Pitstop.ContractManagementAPI.Model;
using Pitstop.Infrastructure.Messaging;
using System.Threading.Tasks;

namespace Pitstop.ContractManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class VatsController : Controller
    {
        IMessagePublisher _messagePublisher;
        ContractManagementDBContext _dbContext;

        public VatsController(ContractManagementDBContext dbContext, IMessagePublisher messagePublisher)
        {
            _dbContext = dbContext;
            _messagePublisher = messagePublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _dbContext.Vats.ToListAsync());
        }

        [HttpGet]
        [Route("{vatId}", Name = "GetByVatId")]
        public async Task<IActionResult> GetByVatId(int vatId)
        {
            var vat = await _dbContext.Vats.FirstOrDefaultAsync(c => c.VatId == vatId);
            if (vat == null)
            {
                return NotFound();
            }
            return Ok(vat);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterVat command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // insert customer
                    VAT vat = Mapper.Map<VAT>(command);
                    _dbContext.Vats.Add(vat);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    //RateRegistered e = Mapper.Map<RateRegistered>(command);
                    //await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                    // return result
                    return CreatedAtRoute("GetByContractId", new { contractId = vat.VatId }, vat);
                }
                return BadRequest();
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator." + " -" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RegisterVat command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // updates contract
                    VAT vat = Mapper.Map<VAT>(command);
                    _dbContext.Vats.Update(vat);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    //RateRegistered e = Mapper.Map<RateRegistered>(command);
                    //await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                    // return result
                    return CreatedAtRoute("GetByContractId", new { contractId = vat.VatId }, vat);
                }
                return BadRequest();
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator." + " -" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVat(int id)
        {
            var vat = await _dbContext.Vats.FirstOrDefaultAsync(c => c.VatId == id);
            if(vat != null)
            {
                _dbContext.Vats.Remove(vat);
                await _dbContext.SaveChangesAsync();
            }
            
            return Ok();
        }
    }
}
