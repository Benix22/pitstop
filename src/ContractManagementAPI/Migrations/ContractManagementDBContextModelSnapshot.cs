using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Pitstop.ContractManagementAPI.DataAccess;

namespace Pitstop.ContractManagementAPI.Migrations
{
    [DbContext(typeof(ContractManagementDBContext))]
    partial class ContractManagementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Pitstop.ContractManagementAPI.Model.Tarifa", b =>
                {
                    b.Property<int>("TarifaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");
                    b.Property<string>("Grupo");
                    b.Property<int>("Dias");
                    b.Property<decimal>("Precio");

                    b.HasKey("TarifaId");

                    b.ToTable("Tarifa");
                });
        }
    }
}
