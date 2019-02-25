using Pitstop.Infrastructure.Messaging;
using System;

namespace Pitstop.Application.VehicleManagement.Commands
{
    public class RegisterInsurance : Command
    {
        public int InsuranceId { get; set; }
        public string Nombre { get; set; }
        public string Poliza { get; set; }
        public string Corredor { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public string Tipo { get; set; }
        public int VehicleId { get; set; }
        public string Matricula { get; set; }

        public RegisterInsurance(Guid messageId,
            int insuranceId,
            string nombre,
            string poliza,
            string corredor,
            DateTime fechaAlta,
            DateTime fechaVencimiento,
            decimal importe,
            string tipo,
            int vehicleId,
            string matricula
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
            Matricula = matricula;
        }
    }
}
