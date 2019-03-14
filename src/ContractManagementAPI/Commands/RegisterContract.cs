using Pitstop.Infrastructure.Messaging;
using System;

namespace Pitstop.ContractManagementAPI.Commands
{
    public class RegisterContract : Command
    {
        public int ContractId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public int RateId { get; set; }

        public RegisterContract(Guid messageId,
            int contractId,
            int customerId,
            int vehicleId,
            int rateId
            ) : base(messageId)
        {
            ContractId = contractId;
            VehicleId = vehicleId;
            CustomerId = customerId;
            RateId = rateId;
        }
    }
}
