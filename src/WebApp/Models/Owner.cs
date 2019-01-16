using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.Application.VehicleManagement.Model
{
    public class Owner
    {
        public int OwnerId { get; set; }

        [Display(Name = "Razón Social")]
        public string RazonSocial
        { get; set; }

        [Display(Name = "CIF")]
        public string CIF
        { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion
        { get; set; }

        [Display(Name = "Contacto")]
        public string Contacto
        { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono
        { get; set; }
    }
}
