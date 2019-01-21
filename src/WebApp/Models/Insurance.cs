using System;
using System.ComponentModel.DataAnnotations;

namespace Pitstop.Application.VehicleManagement.Model
{
    public class Insurance
    {
        public int InsuranceId { get; set; }

        [Display(Name = "Compañía")]
        public string Nombre { get; set; }

        [Display(Name = "Poliza")]
        public string Poliza { get; set; }

        [Display(Name = "Corredor de Seguros")]
        public string Corredor { get; set; }

        [Display(Name = "Fecha de Alta")]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "Fecha de Vencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Importe")]
        public decimal Importe { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        public int VehicleId { get; set; }
    }
}
