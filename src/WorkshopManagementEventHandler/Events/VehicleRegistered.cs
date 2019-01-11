using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.WorkshopManagementEventHandler.Events
{
    public class VehicleRegistered : Event
    {
        public readonly string Matricula;
        public readonly string Marca;
        public readonly string Modelo;
        public readonly string OwnerId;

        public VehicleRegistered(Guid messageId, string matricula, string marca, string modelo, string ownerId) : 
            base(messageId)
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
            OwnerId = ownerId;
        }
    }
}
