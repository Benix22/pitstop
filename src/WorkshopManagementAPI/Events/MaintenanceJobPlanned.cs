﻿using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.WorkshopManagementAPI.Events
{
    public class MaintenanceJobPlanned : Event
    {
        public readonly Guid JobId;
        public readonly DateTime StartTime;
        public readonly DateTime EndTime;
        public readonly (string Id, string Nombre, string Telefono) CustomerInfo;
        public readonly (string LicenseNumber, string Brand, string Type) VehicleInfo;
        public readonly string Description;

        public MaintenanceJobPlanned(Guid messageId, Guid jobId, DateTime startTime, DateTime endTime,
            (string Id, string Nombre, string Telefono) customerInfo,
            (string LicenseNumber, string Brand, string Type) vehicleInfo,
            string description) : base(messageId, MessageTypes.MaintenanceJobPlanned)
        {
            JobId = jobId;
            StartTime = startTime;
            EndTime = endTime;
            CustomerInfo = customerInfo;
            VehicleInfo = vehicleInfo;
            Description = description;
        }
    }
}
