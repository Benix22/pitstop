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
        [Display(Name = "Persona")]
        public bool EsPersona { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Pais")]
        public string Pais { get; set; }
        [Required]
        [Display(Name = "NIF")]
        public string NIF { get; set; }
        [Required]
        [Display(Name = "Fecha Alta")]
        public DateTime FechaAlta { get; set; }
        [Display(Name = "Fecha Baja")]
        public DateTime FechaBaja { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Display(Name = "Pais")]
        public string PaisDireccion { get; set; }
        [Required]
        [Display(Name = "CodigoPostal")]
        public string CodigoPostal { get; set; }
        [Required]
        [Display(Name = "Poblacion")]
        public string Poblacion { get; set; }
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Display(Name = "Telefono")]
        public string Telefono2 { get; set; }
        [Display(Name = "Movil")]
        public string Movil { get; set; }

        [Required]
        [Display(Name = "F. Exp. NIF")]
        public DateTime FechaExpNIF { get; set; }
        [Display(Name = "En")]
        public string PoblacionExpNIF { get; set; }
        [Required]
        [Display(Name = "F. Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "En")]
        public string PoblacionNacimiento { get; set; }
        [Required]
        [Display(Name = "Permiso")]
        public string TipoPermiso { get; set; }
        [Required]
        [Display(Name = "Numero")]
        public string NumeroPermiso { get; set; }
        [Required]
        [Display(Name = "F. Exp. Perm")]
        public DateTime FechaExpPermiso { get; set; }
        [Required]
        [Display(Name = "F. Cad. Perm")]
        public DateTime FechaCadPermiso { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Moroso")]
        public bool Moroso { get; set; }
        [Display(Name = "Bloqueado")]
        public bool Bloqueado { get; set; }

        [Required]
        [Display(Name = "Numero")]
        public string NumeroTarjetaCred { get; set; }
        [Required]
        [Display(Name = "Titular")]
        public string TitularTarjetaCred { get; set; }
        [Required]
        [Display(Name = "F. Cad. ")]
        public DateTime FechaCadTarjetaCred { get; set; }
    }
}
