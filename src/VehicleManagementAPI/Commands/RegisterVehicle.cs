using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.Application.VehicleManagement.Commands
{
    public class RegisterVehicle : Command
    {
        public int Codigo { get; set; }
        public int OwnerId { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Bastidor { get; set; }
        public string Grupo { get; set; }
        public string Daños { get; set; }
        public string Extras { get; set; }
        public string Observaciones { get; set; }
        public string Aviso { get; set; }
        public DateTime PrimerDiaFlota { get; set; }
        public DateTime DevolucionPrevista { get; set; }
        public DateTime UltimoDiaFlota { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaMatriculacion { get; set; }
        public string Km { get; set; }
        public string Combustible { get; set; }
        public string DepositoLitros { get; set; }
        public string Plazas { get; set; }
        public string Puertas { get; set; }

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
