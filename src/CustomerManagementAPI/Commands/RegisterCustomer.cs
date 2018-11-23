using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.CustomerManagementAPI.Commands
{
    public class RegisterCustomer : Command
    {
        public readonly string CustomerId;
        public readonly string Nombre;
        public readonly string Direccion;
        public readonly string CodigoPostal;
        public readonly string Poblacion;
        public readonly string Telefono;
        public readonly string Email;

        public RegisterCustomer(Guid messageId, string customerId, string nombre, string direccion, string codigoPostal, string poblacion, 
            string telefono, string email) : base(messageId, MessageTypes.RegisterCustomer)
        {
            CustomerId = customerId;
            Nombre = nombre;
            Direccion = direccion;
            CodigoPostal = codigoPostal;
            Poblacion = poblacion;
            Telefono = telefono;
            Email = email;
        }
    }
}
