using Pitstop.Infrastructure.Messaging;
using System;

namespace Pitstop.InvoiceService.Events
{
    public class CustomerRegistered : Event
    {
        public readonly string CustomerId;

        public readonly bool EsPersona;
        public readonly string Nombre;
        public readonly string Pais;
        public readonly string NIF;
        public readonly DateTime FechaAlta;
        public readonly DateTime FechaBaja;

        public readonly string Direccion;
        public readonly string PaisDireccion;
        public readonly string CodigoPostal;
        public readonly string Poblacion;
        public readonly string Provincia;
        public readonly string Telefono;
        public readonly string Telefono2;
        public readonly string Movil;

        public readonly DateTime FechaExpNIF;
        public readonly string PoblacionExpNIF;
        public readonly DateTime FechaNacimiento;
        public readonly string PoblacionNacimiento;
        public readonly string TipoPermiso;
        public readonly string NumeroPermiso;
        public readonly DateTime FechaExpPermiso;
        public readonly DateTime FechaCadPermiso;

        public readonly string Email;

        public readonly bool Moroso;
        public readonly bool Bloqueado;

        public readonly string NumeroTarjetaCred;
        public readonly string TitularTarjetaCred;
        public readonly DateTime FechaCadTarjetaCred;

        public CustomerRegistered(Guid messageId,
            string customerId,
            bool esPersona,
            string nombre,
            string pais,
            string nif,
            DateTime fechaAlta,
            DateTime fechaBaja,
            string direccion,
            string paisDireccion,
            string codigoPostal,
            string poblacion,
            string provincia,
            string telefono,
            string telefono2,
            string movil,
            DateTime fechaExpNIF,
            string poblacionExpNIF,
            DateTime fechaNacimiento,
            string poblacionNacimiento,
            string tipoPermiso,
            string numeroPermiso,
            DateTime fechaExpPermiso,
            DateTime fechaCadPermiso,
            string email,
            bool bloqueado,
            bool moroso,
            string numeroTarjetaCred,
            string titulaTarjetaCred,
            DateTime fechaCadTarjetaCred
            ) : base(messageId)
        {
            CustomerId = customerId;

            EsPersona = esPersona;
            Nombre = nombre;
            Pais = pais;
            NIF = nif;
            FechaAlta = fechaAlta;
            FechaBaja = fechaBaja;

            Direccion = direccion;
            PaisDireccion = paisDireccion;
            CodigoPostal = codigoPostal;
            Poblacion = poblacion;
            Provincia = provincia;
            Telefono = telefono;
            Telefono2 = telefono2;
            Movil = movil;

            FechaExpNIF = fechaExpNIF;
            PoblacionExpNIF = poblacionExpNIF;
            FechaNacimiento = fechaNacimiento;
            PoblacionNacimiento = poblacionNacimiento;
            TipoPermiso = tipoPermiso;
            NumeroPermiso = numeroPermiso;
            FechaExpPermiso = fechaExpPermiso;
            FechaCadPermiso = fechaCadPermiso;

            Email = email;

            Moroso = moroso;
            Bloqueado = bloqueado;

            NumeroTarjetaCred = numeroTarjetaCred;
            TitularTarjetaCred = titulaTarjetaCred;
            FechaCadTarjetaCred = fechaCadTarjetaCred;
        }
    }
}
