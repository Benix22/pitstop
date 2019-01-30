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

            modelBuilder.Entity("Pitstop.ContractManagementAPI.Model.Rate", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");
                    b.Property<string>("Poliza");
                    b.Property<string>("Grupo");
                    b.Property<int>("Dias");
                    b.Property<decimal>("Precio");

                    b.HasKey("RateId");

                    b.ToTable("Rate");
                });
        }
    }
}
