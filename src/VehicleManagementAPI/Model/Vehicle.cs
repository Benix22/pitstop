using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.Application.VehicleManagement.Model
{
    public class Vehicle
    {
        public string Codigo { get; set; }
        public string CustomerId { get; set; }        
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
        public string PrimerDiaFlota { get; set; }
        public string DevolucionPrevista { get; set; }
        public string UltimoDiaFlota { get; set; }
        public string FechaFabricacion { get; set; }
        public string FechaMatriculacion { get; set; }
        public string Km { get; set; }
        public string Combustible { get; set; }
        public string DepositoLitros { get; set; }
        public string Plazas { get; set; }
        public string Puertas { get; set; }
    }
}