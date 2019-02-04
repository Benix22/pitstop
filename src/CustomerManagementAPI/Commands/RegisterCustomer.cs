using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitstop.CustomerManagementAPI.Commands
{
    public class RegisterCustomer : Command
    {
        public string CustomerId;

        public bool EsPersona;
        public string Nombre;
        public string Pais;
        public string NIF;
        public DateTime FechaAlta;
        public DateTime FechaBaja;

        public string Direccion;
        public string PaisDireccion;
        public string CodigoPostal;
        public string Poblacion;
        public string Provincia;
        public string Telefono;
        public string Telefono2;
        public string Movil;

        public DateTime FechaExpNIF;
        public string PoblacionExpNIF;
        public DateTime FechaNacimiento;
        public string PoblacionNacimiento;
        public string TipoPermiso;
        public string NumeroPermiso;
        public DateTime FechaExpPermiso;
        public DateTime FechaCadPermiso;
        
        public string Email;
                
        public bool Moroso;
        public bool Bloqueado;

        public string NumeroTarjetaCred;
        public string TitularTarjetaCred;
        public DateTime FechaCadTarjetaCred;

        public RegisterCustomer(Guid messageId,
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
            string titularTarjetaCred,
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
            TitularTarjetaCred = titularTarjetaCred;
            FechaCadTarjetaCred = fechaCadTarjetaCred;
        }
    }
}
