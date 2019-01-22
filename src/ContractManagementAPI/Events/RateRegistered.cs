using Pitstop.Infrastructure.Messaging;
using System;

namespace Pitstop.ContractManagementAPI.Events
{
    public class RateRegistered : Event
    {
        public int RateId { get; set; }

        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public int Dias { get; set; }
        public decimal Precio { get; set; }

        public RateRegistered(Guid messageId,
            int rateId,
            string nombre,
            string grupo,
            int dias,
            decimal precio
            ) : base(messageId)
        {
            RateId = rateId;

            Nombre = nombre;
            Grupo = grupo;
            Dias = dias;
            Precio = precio;
        }
    }
}
