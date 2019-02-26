using Microsoft.AspNetCore.Mvc.Rendering;
using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Models;
using System.Collections.Generic;

namespace Pitstop.ViewModels
{
    public class VehicleInsuranceManagementDetailsViewModel
    {
        public Insurance Insurance { get; set; }

        public Vehicle Vehicle { get; set; }

        public IEnumerable<SelectListItem> Vehicles { get; set; }
    }
}
