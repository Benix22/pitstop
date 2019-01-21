using Microsoft.AspNetCore.Mvc.Rendering;
using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pitstop.ViewModels
{
    public class VehicleInsuranceManagementNewViewModel
    {
        public Insurance Insurance { get; set; }

        public IEnumerable<SelectListItem> Vehicles { get; set; }
    }
}
