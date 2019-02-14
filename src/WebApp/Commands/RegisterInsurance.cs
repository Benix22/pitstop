using Pitstop.Infrastructure.Messaging;
using System;

namespace WebApp.Commands
{
    public class RegisterInsurance : Command
    {
        public readonly int InsuranceId;

        public string Nombre;
        public string Poliza;
        public string Corredor;
        public DateTime FechaAlta;
        public DateTime FechaVencimiento;
        public decimal Importe;
        public string Tipo;
        public int VehicleId;

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
