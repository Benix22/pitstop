using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.WorkshopManagementEventHandler.Events
{
    public class CustomerRegistered : Event
    {
        public readonly string CustomerId;
        public readonly string Nombre;
        public readonly string Telefono;

        public CustomerRegistered(Guid messageId, string customerId, string nombre, string telefono) : 
            base(messageId, MessageTypes.CustomerRegistered)
        {
            CustomerId = customerId;
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
