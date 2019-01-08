using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Pitstop.CustomerManagementAPI.DataAccess;

namespace Pitstop.CustomerManagementAPI.Migrations
{
    [DbContext(typeof(CustomerManagementDBContext))]
    partial class CustomerManagementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Pitstop.CustomerManagementAPI.Model.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EsPersona");
                    b.Property<string>("Nombre");
                    b.Property<string>("Pais");
                    b.Property<string>("NIF");
                    b.Property<DateTime>("FechaAlta");
                    b.Property<DateTime>("FechaBaja");

                    b.Property<string>("Direccion");
                    b.Property<string>("PaisDireccion");
                    b.Property<string>("CodigoPostal");
                    b.Property<string>("Poblacion");
                    b.Property<string>("Provincia");
                    b.Property<string>("Telefono");
                    b.Property<string>("Telefono2");
                    b.Property<string>("Movil");

                    b.Property<DateTime>("FechaExpNIF");
                    b.Property<string>("PoblacionExpNIF");
                    b.Property<DateTime>("FechaNacimiento");
                    b.Property<string>("PoblacionNacimiento");
                    b.Property<string>("TipoPermiso");
                    b.Property<string>("NumeroPermiso");
                    b.Property<DateTime>("FechaExpPermiso");
                    b.Property<DateTime>("FechaCadPermiso");

                    b.Property<string>("Email");

                    b.Property<bool>("Moroso");
                    b.Property<bool>("Bloqueado");

                    b.Property<string>("NumeroTarjetaCred");
                    b.Property<string>("TitularTarjetaCred");
                    b.Property<DateTime>("FechaCadTarjetaCred");


                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });
        }
    }
}
