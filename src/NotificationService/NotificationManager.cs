using Newtonsoft.Json.Linq;
using Pitstop.Infrastructure.Messaging;
using Pitstop.NotificationService.Events;
using Pitstop.NotificationService.Model;
using Pitstop.NotificationService.NotificationChannels;
using Pitstop.NotificationService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Pitstop.NotificationService
{
    public class NotificationManager : IMessageHandlerCallback
    {
        IMessageHandler _messageHandler;
        INotificationRepository _repo;
        IEmailNotifier _emailNotifier;

        public NotificationManager(IMessageHandler messageHandler, INotificationRepository repo, IEmailNotifier emailNotifier)
        {
            _messageHandler = messageHandler;
            _repo = repo;
            _emailNotifier = emailNotifier;
        }

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }

        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            JObject messageObject = MessageSerializer.Deserialize(message);
            switch (messageType)
            {
                case "CustomerRegistered":
                    await HandleAsync(messageObject.ToObject<CustomerRegistered>());
                    break;
                case "MaintenanceJobPlanned":
                    await HandleAsync(messageObject.ToObject<MaintenanceJobPlanned>());
                    break;
                case "MaintenanceJobFinished":
                    await HandleAsync(messageObject.ToObject<MaintenanceJobFinished>());
                    break;
                case "DayHasPassed":
                    await HandleAsync(messageObject.ToObject<DayHasPassed>());
                    break;
                default:
                    break;
            }
            return true;
        }

        private async Task HandleAsync(CustomerRegistered cr)
        {
            Customer customer = new Customer
            {
                CustomerId = cr.CustomerId,

                EsPersona = cr.EsPersona,
                Nombre = cr.Nombre,
                Pais = cr.Pais,
                NIF = cr.NIF,
                FechaAlta = cr.FechaAlta,
                FechaBaja = cr.FechaBaja,

                Direccion = cr.Direccion,
                PaisDireccion = cr.PaisDireccion,
                CodigoPostal = cr.CodigoPostal,
                Poblacion = cr.Poblacion,
                Provincia = cr.Provincia,
                Telefono = cr.Telefono,
                Telefono2 = cr.Telefono2,
                Movil = cr.Movil,

                FechaExpNIF = cr.FechaExpNIF,
                PoblacionExpNIF = cr.PoblacionExpNIF,
                FechaNacimiento = cr.FechaNacimiento,
                PoblacionNacimiento = cr.PoblacionNacimiento,
                TipoPermiso = cr.TipoPermiso,
                NumeroPermiso = cr.NumeroPermiso,
                FechaExpPermiso = cr.FechaExpPermiso,
                FechaCadPermiso = cr.FechaCadPermiso,

                Email = cr.Email,

                Moroso = cr.Moroso,
                Bloqueado = cr.Bloqueado,

                NumeroTarjetaCred = cr.NumeroTarjetaCred,
                TitularTarjetaCred = cr.TitularTarjetaCred,
                FechaCadTarjetaCred = cr.FechaCadTarjetaCred
        };

            await _repo.RegisterCustomerAsync(customer);
        }

        private async Task HandleAsync(MaintenanceJobPlanned mjp)
        {
            MaintenanceJob job = new MaintenanceJob
            {
                JobId = mjp.JobId.ToString(),
                CustomerId = mjp.CustomerInfo.Id,
                LicenseNumber = mjp.VehicleInfo.LicenseNumber,
                StartTime = mjp.StartTime,
                Description = mjp.Description
            };

            await _repo.RegisterMaintenanceJobAsync(job);
        }

        private async Task HandleAsync(MaintenanceJobFinished mjf)
        {
            await _repo.RemoveMaintenanceJobsAsync(new string[] { mjf.JobId.ToString() });
        }

        private async Task HandleAsync(DayHasPassed dhp)
        {
            DateTime today = DateTime.Now;

            IEnumerable<MaintenanceJob> jobsToNotify = await _repo.GetMaintenanceJobsForTodayAsync(today);
            foreach (var jobsPerCustomer in jobsToNotify.GroupBy(job => job.CustomerId))
            {
                // build notification body
                string customerId = jobsPerCustomer.Key;
                Customer customer = await _repo.GetCustomerAsync(customerId);
                StringBuilder body = new StringBuilder();
                body.AppendLine($"Dear {customer.Nombre},\n");
                body.AppendLine($"We would like to remind you that you have an appointment with us for maintenance on your vehicle(s):\n");
                foreach (MaintenanceJob job in jobsPerCustomer)
                {
                    body.AppendLine($"- {job.StartTime.ToString("dd-MM-yyyy")} at {job.StartTime.ToString("HH:mm")} : " +
                        $"{job.Description} on vehicle with license-number {job.LicenseNumber}");
                }

                body.AppendLine($"\nPlease make sure you're present at least 10 minutes before the (first) job is planned.");
                body.AppendLine($"Once arrived, you can notify your arrival at our front-desk.\n");
                body.AppendLine($"Greetings,\n");
                body.AppendLine($"The PitStop crew");

                // sent notification
                await _emailNotifier.SendEmailAsync(
                    customer.Email, "noreply@pitstop.nl", "Vehicle maintenance reminder", body.ToString());

                // remove jobs for which a notification was sent
                await _repo.RemoveMaintenanceJobsAsync(jobsPerCustomer.Select(job => job.JobId));
            }
        }
    }
}
