using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Codigo Postal")]
        public string CodigoPostal { get; set; }

        [Required]
        [Display(Name = "Poblacion")]
        public string Poblacion { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress()]
        public string Email { get; set; }
    }
}
