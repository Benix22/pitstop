﻿using Pitstop.Infrastructure.Messaging;
using System;

namespace WebApp.Commands
{
    public class RegisterRate : Command
    {
        public readonly int RateId;

        public string Nombre { get; set; }
        public string Poliza { get; set; }
        public string Grupo { get; set; }
        public int Dias { get; set; }
        public decimal Precio { get; set; }

        public RegisterRate(Guid messageId,
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
