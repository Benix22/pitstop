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
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pitstop.Application.VehicleManagement.Model.Owner", b =>
            {
                b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd();

                b.Property<string>("RazonSocial");
                b.Property<string>("CIF");
                b.Property<string>("Direccion");
                b.Property<string>("Contacto");
                b.Property<string>("Telefono");
                b.HasKey("OwnerId");

                b.ToTable("Owner");
            });

            modelBuilder.Entity("Pitstop.Application.VehicleManagement.Model.Vehicle", b =>
            {
                b.Property<int>("Codigo")
                    .ValueGeneratedOnAdd();

                b.Property<int>("OwnerId");
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
                b.HasKey("Codigo");

                b.ToTable("Vehicle");
            });

            modelBuilder.Entity("Pitstop.Application.VehicleManagement.Model.Insurance", b =>
            {
                b.Property<int>("InsuranceId")
                        .ValueGeneratedOnAdd();

                b.Property<string>("Nombre");
                b.Property<string>("Poliza");
                b.Property<string>("Corredor");
                b.Property<DateTime>("FechaAlta");
                b.Property<DateTime>("FechaVencimiento");
                b.Property<decimal>("Importe");
                b.Property<string>("Tipo");
                b.Property<int>("VehicleId");
                b.HasKey("InsuranceId");

                b.ToTable("Insurance");
            });
        }
    }
}
