using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Pitstop.Application.VehicleManagement.DataAccess;

namespace Pitstop.Application.VehicleManagement.Migrations
{
    [DbContext(typeof(VehicleManagementDBContext))]
    partial class VehicleManagementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Pitstop.Application.VehicleManagement.Model.Owner", b =>
            {
                b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd();

                b.Property<string>("RazonSocial");
                b.Property<string>("CIF");
                b.Property<string>("Direccion");
                b.Property<string>("Contacto");
                b.Property<string>("Telefono");

                b.ToTable("Owner");
            });

            modelBuilder.Entity("Pitstop.Application.VehicleManagement.Model.Vehicle", b =>
            {
                b.Property<int>("Codigo")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Matricula");
                b.Property<string>("Marca");
                b.Property<string>("Modelo");
                b.Property<string>("Color");
                b.Property<string>("Bastidor");
                b.Property<string>("Grupo");
                b.Property<string>("Daños");
                b.Property<string>("Extras");
                b.Property<string>("Observaciones");
                b.Property<string>("Aviso");
                b.Property<DateTime>("PrimerDiaFlota");
                b.Property<DateTime>("DevolucionPrevista");
                b.Property<DateTime>("UltimoDiaFlota");
                b.Property<DateTime>("FechaFabricacion");
                b.Property<DateTime>("FechaMatriculacion");
                b.Property<string>("Km");
                b.Property<string>("Combustible");
                b.Property<string>("DepositoLitros");
                b.Property<string>("Plazas");
                b.Property<string>("Puertas");

                b.ToTable("Vehicle");
            });
        }
    }
}
