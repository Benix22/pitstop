using Pitstop.Infrastructure.Messaging;
using System;

namespace Pitstop.ContractManagementAPI.Commands
{
    public class RegisterVat : Command
    {
        public int VatId { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public bool Current { get; set; }

        public RegisterVat(Guid messageId,
            int vatId,
            string nombre,
            int tipo,
            bool current
            ) : base(messageId)
        {
            VatId = vatId;
            Nombre = nombre;
            Tipo = tipo;
            Current = current;
        }
    }
}
