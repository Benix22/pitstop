using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Pitstop.Infrastructure.Messaging;
using Pitstop.WorkshopManagementEventHandler.DataAccess;
using Pitstop.WorkshopManagementEventHandler.Events;
using Pitstop.WorkshopManagementEventHandler.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pitstop.WorkshopManagementEventHandler
{
    public class EventHandler : IMessageHandlerCallback
    {
        WorkshopManagementDBContext _dbContext;
        IMessageHandler _messageHandler;

        public EventHandler(IMessageHandler messageHandler, WorkshopManagementDBContext dbContext)
        {
            _messageHandler = messageHandler;
            _dbContext = dbContext;
        }

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }

        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            JObject messageObject = MessageSerializer.Deserialize(message);
            try
            {
                switch (messageType)
                {
                    case "CustomerRegistered":
                        await HandleAsync(messageObject.ToObject<CustomerRegistered>());
                        break;
                    case "VehicleRegistered":
                        await HandleAsync(messageObject.ToObject<VehicleRegistered>());
                        break;
                    case "MaintenanceJobPlanned":
                        await HandleAsync(messageObject.ToObject<MaintenanceJobPlanned>());
                        break;
                    case "MaintenanceJobFinished":
                        await HandleAsync(messageObject.ToObject<MaintenanceJobFinished>());
                        break;
                }
            }
            catch(Exception ex)
            {
                string messageId = messageObject.Property("MessageId") != null ? messageObject.Property("MessageId").Value<string>() : "[unknown]";
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", messageType, messageId);
            }

            // always akcnowledge message - any errors need to be dealt with locally.
            return true; 
        }

        private async Task<bool> HandleAsync(VehicleRegistered e)
        {
            Log.Information("Vehicle registered: {LicenseNumber}, {Brand}, {Type}, Owner Id: {OwnerId}", 
                e.Matricula, e.Marca, e.Modelo, e.OwnerId);

            try
            {
                await _dbContext.Vehicles.AddAsync(new Vehicle
                {
                    Matricula = e.Matricula,
                    Marca = e.Marca,
                    Modelo = e.Modelo,
                    OwnerId = e.OwnerId
                });
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                Console.WriteLine($"Skipped adding vehicle with matricula {e.Matricula}.");
            }

            return true;
        }

        private async Task<bool> HandleAsync(CustomerRegistered e)
        {
            Log.Information("Customer registered: {CustomerId}, {Nombre}, {Telefono}", 
                e.CustomerId, e.Nombre, e.Telefono);

            try
            {
                await _dbContext.Customers.AddAsync(new Customer
                {
                    CustomerId = e.CustomerId,
                    Nombre = e.Nombre,
                    Telefono = e.Telefono
                });
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                Log.Warning("Skipped adding customer with customer id {CustomerId}.", e.CustomerId);
            }

            return true; 
        }

        private async Task<bool> HandleAsync(MaintenanceJobPlanned e)
        {
            Log.Information("Maintenance job planned: {JobId}, {StartTime}, {EndTime}, {CustomerName}, {LicenseNumber}", 
                e.JobId, e.StartTime, e.EndTime, e.CustomerInfo.Nombre, e.VehicleInfo.Matricula);

            try
            {
                // determine customer
                Customer customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == e.CustomerInfo.Id);
                if (customer == null)
                {
                    customer = new Customer
                    {
                        CustomerId = e.CustomerInfo.Id,
                        Nombre = e.CustomerInfo.Nombre,
                        Telefono = e.CustomerInfo.Telefono
                    };
                }

                // determine vehicle
                Vehicle vehicle = await _dbContext.Vehicles.FirstOrDefaultAsync(v => v.Matricula == e.VehicleInfo.Matricula);
                if (vehicle == null)
                {
                    vehicle = new Vehicle
                    {
                        Matricula = e.VehicleInfo.Matricula,
                        Marca = e.VehicleInfo.Marca,
                        Modelo = e.VehicleInfo.Modelo,
                        OwnerId = customer.CustomerId
                    };
                }

                // insert maintetancejob
                await _dbContext.MaintenanceJobs.AddAsync(new MaintenanceJob
                {
                    Id = e.JobId,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    Customer = customer,
                    Vehicle = vehicle,       
                    WorkshopPlanningDate = e.StartTime.Date,
                    Description = e.Description
                });
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                Log.Warning("Skipped adding maintenance job with id {JobId}.", e.JobId);
            }

            return true;
        }

        private async Task<bool> HandleAsync(MaintenanceJobFinished e)
        {
            Log.Information("Maintenance job finished: {JobId}, {ActualStartTime}, {EndTime}",
                e.JobId, e.StartTime, e.EndTime);

            try
            {
                // insert maintetancejob
                var job = await _dbContext.MaintenanceJobs.FirstOrDefaultAsync(j => j.Id == e.JobId);
                job.ActualStartTime = e.StartTime;
                job.ActualEndTime = e.EndTime;
                job.Notes = e.Notes;
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                Log.Warning("Skipped adding maintenance job with id {JobId}.", e.JobId);
            }

            return true;
        }
    }
}
