using Pitstop.Infrastructure.Messaging;
using System;

namespace WebApp.Commands
{
    public class RegisterRate : Command
    {
        public readonly int RateId;

        public readonly string Nombre;
        public readonly string Grupo;
        public readonly int Dias;
        public readonly decimal Precio;

        public RegisterRate(Guid messageId,
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
