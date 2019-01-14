using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.Application.VehicleOwnerManagement.Commands
{
    public class RegisterOwner : Command
    {
        public readonly int OwnerId;
        public readonly string RazonSocial;
        public readonly string CIF;
        public readonly string Direccion;
        public readonly string Contacto;
        public readonly string Telefono;

        public RegisterOwner(Guid messageId,
            int ownerId,
            string razonSocial,
            string cif,
            string direccion,
            string contacto,
            string telefono
            ) : 
            base(messageId)
        {
            OwnerId = ownerId;
            RazonSocial = razonSocial;
            CIF = cif;
            Direccion = direccion;
            Contacto = contacto;
            Telefono = telefono;
        }
    }
}
