using Pitstop.Application.VehicleManagement.Model;
using System.Collections.Generic;

namespace Pitstop.ViewModels
{
    public class VehicleInsuranceManagementViewModel
    {
        public IEnumerable<Insurance> Insurances { get; set; }
    }
}
