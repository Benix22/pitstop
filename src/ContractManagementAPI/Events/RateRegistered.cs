using Pitstop.Infrastructure.Messaging;
using System;

namespace Pitstop.ContractManagementAPI.Events
{
    public class RateRegistered : Event
    {
        public readonly int RateId;

        public readonly string Nombre;
        public readonly string Poliza;
        public readonly string Grupo;
        public readonly int Dias;
        public readonly decimal Precio;

        public RateRegistered(Guid messageId,
            int rateId,
            string nombre,
            string poliza,
            string grupo,
            int dias,
            decimal precio
            ) : base(messageId)
        {
            RateId = rateId;

            Nombre = nombre;
            Poliza = poliza;
            Grupo = grupo;
            Dias = dias;
            Precio = precio;
        }
    }
}
