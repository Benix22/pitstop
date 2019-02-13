using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pitstop.Application.VehicleManagement.Model
{
    public class Insurance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsuranceId { get; set; }
        public string Nombre { get; set; }
        public string Poliza { get; set; }
        public string Corredor { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public string Tipo { get; set; }
        public int VehicleId { get; set; }
    }
}
