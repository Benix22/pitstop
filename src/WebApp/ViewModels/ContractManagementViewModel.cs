using Pitstop.Models;
using System.Collections.Generic;

namespace Pitstop.ViewModels.ContractManagement
{
    public class ContractManagementViewModel
    {
        public IEnumerable<Rate> Rates { get; set; }

        public IEnumerable<VAT> Vats { get; set; }
    }
}
