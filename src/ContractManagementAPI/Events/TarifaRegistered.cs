using Pitstop.Infrastructure.Messaging;
using System;

namespace Pitstop.ContractManagementAPI.Events
{
    public class TarifaRegistered : Event
    {
        public int TarifaId { get; set; }

        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public int Dias { get; set; }
        public decimal Precio { get; set; }

        public TarifaRegistered(Guid messageId,
            int tarifaId,
            string nombre,
            string grupo,
            int dias,
            decimal precio
            ) : base(messageId)
        {
            TarifaId = tarifaId;

            Nombre = nombre;
            Grupo = grupo;
            Dias = dias;
            Precio = precio;
        }
    }
}
