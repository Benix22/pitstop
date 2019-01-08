using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.InvoiceService.Model
{
    public class Customer
    {
        public string CustomerId { get; set; }

        public bool EsPersona { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string NIF { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }

        public string Direccion { get; set; }
        public string PaisDireccion { get; set; }
        public string CodigoPostal { get; set; }
        public string Poblacion { get; set; }
        public string Provincia { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Movil { get; set; }

        public DateTime FechaExpNIF { get; set; }
        public string PoblacionExpNIF { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PoblacionNacimiento { get; set; }
        public string TipoPermiso { get; set; }
        public string NumeroPermiso { get; set; }
        public DateTime FechaExpPermiso { get; set; }
        public DateTime FechaCadPermiso { get; set; }

        public string Email { get; set; }

        public bool Moroso { get; set; }
        public bool Bloqueado { get; set; }

        public string NumeroTarjetaCred { get; set; }
        public string TitularTarjetaCred { get; set; }
        public DateTime FechaCadTarjetaCred { get; set; }
    }
}
