using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.ViewModels
{
    public class VehicleOwnerManagementDetailsViewModel
    {
        public Owner Owner { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
