﻿using Pitstop.Infrastructure.Messaging;
using System;

namespace WebApp.Commands
{
    public class PlanMaintenanceJob : Command
    {
        public readonly Guid JobId;
        public readonly DateTime StartTime;
        public readonly DateTime EndTime;
        public readonly (string Id, string Name, string TelephoneNumber) CustomerInfo;
        public readonly (int Codigo, string Marca, string Modelo) VehicleInfo;
        public readonly string Description;

        public PlanMaintenanceJob(Guid messageId, Guid jobId, DateTime startTime, DateTime endTime,
            //(string Id, string Name, string TelephoneNumber) customerInfo,
            (int Codigo, string Marca, string Modelo) vehicleInfo,
            string description) : base(messageId)
        {
            JobId = jobId;
            StartTime = startTime;
            EndTime = endTime;
           // CustomerInfo = customerInfo;
            VehicleInfo = vehicleInfo;
            Description = description;
        }
    }
}
