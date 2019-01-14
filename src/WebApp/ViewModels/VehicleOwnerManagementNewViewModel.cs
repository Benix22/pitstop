using Microsoft.AspNetCore.Mvc.Rendering;
using Pitstop.Application.VehicleManagement.Model;
using Pitstop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pitstop.ViewModels
{
    public class VehicleOwnerManagementNewViewModel
    {
        public Owner Owner { get; set; }
    }
}
