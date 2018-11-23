using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.CustomerManagementAPI.Model
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string Poblacion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
