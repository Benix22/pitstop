using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.ViewModels
{
    public class VehicleOwnerManagementViewModel
    {
        public IEnumerable<Owner> Owners { get; set; }
    }
}
