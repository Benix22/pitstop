namespace Pitstop.ViewModels
{
    public class VehicleOwnerManagementOfflineViewModel
    {
        public string ErrorMessage { get; set; }

        public  VehicleOwnerManagementOfflineViewModel(string erroMessage)
        {
            ErrorMessage = erroMessage;
        }
       
    }
}
