using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.WorkshopManagementAPI.Domain
{
    public class Customer
    {
        public string CustomerId { get; private set; }
        public string Nombre { get; private set; }
        public string Telefono { get; private set; }

        public Customer(string customerId, string nombre, string telefono)
        {
            CustomerId = customerId;
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
