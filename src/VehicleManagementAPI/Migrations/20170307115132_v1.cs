using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pitstop.Application.VehicleManagement.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: false),
                    CIF = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Contacto = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false),

                    OwnerId = table.Column<int>(nullable: false),
                    Matricula = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Bastidor = table.Column<string>(nullable: true),
                    Grupo = table.Column<string>(nullable: true),
                    Daños = table.Column<string>(nullable: true),
                    Extras = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    Aviso = table.Column<string>(nullable: true),
                    Km = table.Column<string>(nullable: true),
                    Combustible = table.Column<string>(nullable: true),
                    DepositoLitros = table.Column<string>(nullable: true),
                    Plazas = table.Column<string>(nullable: true),
                    Puertas = table.Column<string>(nullable: true),

                    PrimerDiaFlota = table.Column<DateTime>(nullable: true),
                    DevolucionPrevista = table.Column<DateTime>(nullable: true),
                    UltimoDiaFlota = table.Column<DateTime>(nullable: true),
                    FechaFabricacion = table.Column<DateTime>(nullable: true),
                    FechaMatriculacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Vehicle_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
               name: "Insurance",
               columns: table => new
               {
                   InsuranceId = table.Column<int>(nullable: false),
                   Nombre = table.Column<string>(nullable: false),
                   Poliza = table.Column<string>(nullable: false),
                   Corredor = table.Column<string>(nullable: true),
                   FechaAlta = table.Column<DateTime>(nullable: true),
                   FechaVencimiento = table.Column<DateTime>(nullable: true),
                   Importe = table.Column<decimal>(nullable: true),
                   Tipo = table.Column<string>(nullable: true),
                   Codigo = table.Column<int>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Insurance", x => x.InsuranceId);
                   table.ForeignKey(
                       name: "FK_Insurance_Codigo",
                       column: x => x.Codigo,
                       principalTable: "Insurance",
                       principalColumn: "InsuranceId",
                       onDelete: ReferentialAction.Restrict);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Insurance");
        }
    }
}
