using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pitstop.Models
{
    public class Vehicle
    {
        [Required]
        [Display(Name = "Código")]
        public Guid Codigo { get; set; }

        [Display(Name = "Cliente")]
        public string CustomerId { get; set; }

        [Required]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Bastidor")]
        public string Bastidor { get; set; }

        [Display(Name = "Grupo")]
        public string Grupo { get; set; }

        [Display(Name = "Daños")]
        public string Daños { get; set; }

        [Display(Name = "Extras")]
        public string Extras { get; set; }

        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

        [Display(Name = "Aviso")]
        public string Aviso { get; set; }

        [Required]
        [Display(Name = "Primer Dia Flota")]
        public DateTime PrimerDiaFlota { get; set; }

        [Display(Name = "Devolución Prevista")]
        public DateTime DevolucionPrevista { get; set; }

        [Display(Name = "Ultimo Dia Flota")]
        public DateTime UltimoDiaFlota { get; set; }
        [Required]
        [Display(Name = "Fecha Fabricación")]
        public DateTime FechaFabricacion { get; set; }
        [Required]
        [Display(Name = "Fecha Matriculación")]
        public DateTime FechaMatriculacion { get; set; }

        [Display(Name = "Km")]
        public string Km { get; set; }

        [Display(Name = "Combustible")]
        public string Combustible { get; set; }

        [Display(Name = "Deposito (l)")]
        public string DepositoLitros { get; set; }

        [Required]
        [Display(Name = "Plazas")]
        public string Plazas { get; set; }
        [Required]
        [Display(Name = "Puertas")]
        public string Puertas { get; set; }
    }
}
