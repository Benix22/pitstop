using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pitstop.CustomerManagementAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),

                    EsPersona = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Pais = table.Column<string>(nullable: true),
                    NIF = table.Column<string>(nullable: false),
                    FechaAlta = table.Column<DateTime>(nullable: false),
                    FechaBaja = table.Column<DateTime>(nullable: true),

                    Direccion = table.Column<string>(nullable: false),
                    PaisDireccion = table.Column<string>(nullable: true),
                    CodigoPostal = table.Column<string>(nullable: false),
                    Poblacion = table.Column<string>(nullable: false),
                    Provincia = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Telefono2 = table.Column<string>(nullable: true),
                    Movil = table.Column<string>(nullable: true),

                    FechaExpNIF = table.Column<DateTime>(nullable: false),
                    PoblacionExpNIF = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    PoblacionNacimiento = table.Column<string>(nullable: true),
                    TipoPermiso = table.Column<string>(nullable: false),
                    NumeroPermiso = table.Column<string>(nullable: false),
                    FechaExpPermiso = table.Column<DateTime>(nullable: false),
                    FechaCadPermiso = table.Column<DateTime>(nullable: false),

                    Email = table.Column<string>(nullable: false),

                    Moroso = table.Column<bool>(nullable: false),
                    Bloqueado = table.Column<bool>(nullable: false),

                    NumeroTarjetaCred = table.Column<string>(nullable: false),
                    TitularTarjetaCred = table.Column<string>(nullable: false),
                    FechaCadTarjetaCred = table.Column<DateTime>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
