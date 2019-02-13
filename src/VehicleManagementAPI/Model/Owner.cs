using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.Application.VehicleManagement.Model
{
    public class Owner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }
        public string RazonSocial { get; set; }
        public string CIF { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
    }
}
