using Microsoft.AspNetCore.Mvc.Rendering;
using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.ViewModels
{
    public class VehicleManagementDetailsViewModel
    {
        public Vehicle Vehicle { get; set; }
        public IEnumerable<SelectListItem> Owners { get; set; }
    }
}
