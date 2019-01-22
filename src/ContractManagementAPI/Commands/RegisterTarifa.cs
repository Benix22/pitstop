using Pitstop.Infrastructure.Messaging;
using System;

namespace Pitstop.ContractManagementAPI.Commands
{
    public class RegisterTarifa : Command
    {
        public readonly int TarifaId;

        public readonly string Nombre;
        public readonly string Grupo;
        public readonly int Dias;
        public readonly decimal Precio;

        public RegisterTarifa(Guid messageId,
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
