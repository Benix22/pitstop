using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.WorkshopManagementAPI.Domain
{
    public class Vehicle
    {
        public string Matricula { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string OwnerId { get; private set; }

        public Vehicle(string matricula, string marca, string modelo, string ownerId)
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
            OwnerId = ownerId;
        }
    }
}
