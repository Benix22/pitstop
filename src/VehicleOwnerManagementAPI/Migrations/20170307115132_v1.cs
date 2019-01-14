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
                    Codigo = table.Column<string>(nullable: false),

                    Matricula = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
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
                        column: x => x.CustomerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
