using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.Application.VehicleManagement.Events
{
    public class InsuranceRegistered : Event
    {
        public readonly int InsuranceId;
        public readonly string Nombre;
        public readonly string Poliza;
        public readonly string Corredor;
        public readonly DateTime FechaAlta;
        public readonly DateTime FechaVencimiento;
        public readonly decimal Importe;
        public readonly string Tipo;
        public readonly int VehicleId;

        public InsuranceRegistered(Guid messageId,
            int insuranceId,
            string nombre,
            string poliza,
            string corredor,
            DateTime fechaAlta,
            DateTime fechaVencimiento,
            decimal importe,
            string tipo,
            int vehicleId
            ) :
            base(messageId)
        {
            InsuranceId = insuranceId;
            Nombre = nombre;
            Poliza = poliza;
            Corredor = corredor;
            FechaAlta = fechaAlta;
            FechaVencimiento = fechaVencimiento;
            Importe = importe;
            Tipo = tipo;
            VehicleId = vehicleId;
        }
    }
}
