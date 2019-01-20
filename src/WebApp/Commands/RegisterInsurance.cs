using Pitstop.Infrastructure.Messaging;
using System;

namespace WebApp.Commands
{
    public class RegisterInsurance : Command
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

        public RegisterInsurance(Guid messageId,
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
