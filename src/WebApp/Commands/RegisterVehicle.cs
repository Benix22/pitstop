using Pitstop.Infrastructure.Messaging;
using System;

namespace WebApp.Commands
{
    public class RegisterVehicle : Command
    {
        public readonly int Codigo;

        public int OwnerId;
        public string Matricula;
        public string Marca;
        public string Modelo;
        public string Color;
        public string Bastidor;
        public string Grupo;
        public string Daños;
        public string Extras;
        public string Observaciones;
        public string Aviso;
        public DateTime PrimerDiaFlota;
        public DateTime DevolucionPrevista;
        public DateTime UltimoDiaFlota;
        public DateTime FechaFabricacion;
        public DateTime FechaMatriculacion;
        public string Km;
        public string Combustible;
        public string DepositoLitros;
        public string Plazas;
        public string Puertas;

        public RegisterVehicle(Guid messageId,
            int codigo,
            int ownerId,
            string matricula,
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
            OwnerId = ownerId;
            Matricula = matricula;
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
