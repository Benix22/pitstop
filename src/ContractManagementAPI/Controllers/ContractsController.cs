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
    public class ContractsController : Controller
    {
        IMessagePublisher _messagePublisher;
        ContractManagementDBContext _dbContext;

        public ContractsController(ContractManagementDBContext dbContext, IMessagePublisher messagePublisher)
        {
            _dbContext = dbContext;
            _messagePublisher = messagePublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _dbContext.Contracts.ToListAsync());
        }

        [HttpGet]
        [Route("{contractId}", Name = "GetByContractId")]
        public async Task<IActionResult> GetByContractId(int contractId)
        {
            var contract = await _dbContext.Contracts.FirstOrDefaultAsync(c => c.ContractId == contractId);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterContract command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // insert customer
                    Contract contract = Mapper.Map<Contract>(command);
                    _dbContext.Contracts.Add(contract);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    //RateRegistered e = Mapper.Map<RateRegistered>(command);
                    //await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                    // return result
                    return CreatedAtRoute("GetByContractId", new { contractId = contract.ContractId }, contract);
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
        public async Task<IActionResult> UpdateAsync([FromBody] RegisterContract command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // insert contract
                    Contract contract = Mapper.Map<Contract>(command);
                    _dbContext.Contracts.Update(contract);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    //RateRegistered e = Mapper.Map<RateRegistered>(command);
                    //await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                    // return result
                    return CreatedAtRoute("GetByContractId", new { contractId = contract.ContractId }, contract);
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
        public async Task<IActionResult> DeleteContract(int id)
        {
            var contract = await _dbContext.Contracts.FirstOrDefaultAsync(c => c.ContractId == id);
            if(contract != null)
            {
                _dbContext.Contracts.Remove(contract);
                await _dbContext.SaveChangesAsync();
            }
            
            return Ok();
        }
    }
}
