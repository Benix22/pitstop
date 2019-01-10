using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.Application.VehicleManagement.Events
{
    public class VehicleRegistered : Event
    {
        public readonly string Codigo;
        public readonly string CustomerId;
        public readonly string Matricula;
        public readonly string Marca;
        public readonly string Modelo;
        public readonly string Color;
        public readonly string Bastidor;
        public readonly string Grupo;
        public readonly string Daños;
        public readonly string Extras;
        public readonly string Observaciones;
        public readonly string Aviso;
        public readonly DateTime PrimerDiaFlota;
        public readonly DateTime DevolucionPrevista;
        public readonly DateTime UltimoDiaFlota;
        public readonly DateTime FechaFabricacion;
        public readonly DateTime FechaMatriculacion;
        public readonly string Km;
        public readonly string Combustible;
        public readonly string DepositoLitros;
        public readonly string Plazas;
        public readonly string Puertas;

        public VehicleRegistered(Guid messageId,
            string codigo,
            string matricula,
            string ownerId,
            string marca,
            string modelo,
            string color,
            string bastidor,
            string grupo,
            string daños,
            string extras,
            string observaciones,
            string aviso,
            DateTime primerDiaFlota,
            DateTime devolucionPrevista,
            DateTime ultimoDiaFlota,
            DateTime fechaFabricacion,
            DateTime fechaMatriculacion,
            string km,
            string combustible,
            string depositoLitros,
            string plazas,
            string puertas
            ) :
            base(messageId)
        {
            Codigo = codigo;
            Matricula = matricula;
            CustomerId = ownerId;
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Bastidor = bastidor;
            Grupo = grupo;
            Daños = daños;
            Extras = extras;
            Observaciones = observaciones;
            Aviso = aviso;
            PrimerDiaFlota = primerDiaFlota;
            DevolucionPrevista = devolucionPrevista;
            UltimoDiaFlota = ultimoDiaFlota;
            FechaFabricacion = fechaFabricacion;
            FechaMatriculacion = fechaMatriculacion;
            Km = km;
            Combustible = combustible;
            DepositoLitros = depositoLitros;
            Plazas = plazas;
            Puertas = puertas;
        }
    }
}
