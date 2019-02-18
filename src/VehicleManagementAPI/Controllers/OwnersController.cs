using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pitstop.Application.VehicleManagement.DataAccess;
using Pitstop.Application.VehicleManagement.Events;
using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Application.VehicleOwnerManagement.Commands;
using Pitstop.Infrastructure.Messaging;
using System;
using System.Threading.Tasks;

namespace Pitstop.Application.VehicleManagement.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OwnersController : Controller
    {
        IMessagePublisher _messagePublisher;
        VehicleManagementDBContext _dbContext;

        public OwnersController(VehicleManagementDBContext dbContext, IMessagePublisher messagePublisher)
        {
            _dbContext = dbContext;
            _messagePublisher = messagePublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var items = await _dbContext.Owners.ToListAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("{ownerId}", Name = "GetOwnerById")]
        public async Task<IActionResult> GetById(int ownerId)
        {
            var owner = await _dbContext.Owners.FirstOrDefaultAsync(v => v.OwnerId == ownerId);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterOwner command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // insert owner
                    Owner owner = Mapper.Map<Owner>(command);
                    _dbContext.Owners.Add(owner);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    //var e = Mapper.Map<OwnerRegistered>(command);
                    //await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                    //return result
                    return CreatedAtRoute("GetOwnerById", new { ownerID = owner.OwnerId }, owner);
                }
                return BadRequest();
            }
            catch (Exception Ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
