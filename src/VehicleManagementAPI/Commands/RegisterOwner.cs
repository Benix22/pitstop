using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.Application.VehicleOwnerManagement.Commands
{
    public class RegisterOwner : Command
    {
        public int OwnerId { get; set; }
        public string RazonSocial { get; set; }
        public string CIF { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }

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
