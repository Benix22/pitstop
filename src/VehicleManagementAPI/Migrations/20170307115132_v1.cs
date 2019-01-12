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
                name: "Vehicle",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Matricula = table.Column<string>(nullable: false),
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
                    PrimerDiaFlota = table.Column<DateTime>(nullable: false),
                    DevolucionPrevista = table.Column<DateTime>(nullable: true),
                    UltimoDiaFlota = table.Column<DateTime>(nullable: true),
                    FechaFabricacion = table.Column<DateTime>(nullable: false),
                    FechaMatriculacion = table.Column<DateTime>(nullable: false),
                    Km = table.Column<string>(nullable: true),
                    Combustible = table.Column<string>(nullable: true),
                    DepositoLitros = table.Column<string>(nullable: true),
                    Plazas = table.Column<string>(nullable: false),
                    Puertas = table.Column<string>(nullable: false),
                    LastUpdateTimestamp = table.Column<DateTimeOffset>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Codigo);
                    //table.ForeignKey("FK_Customer", x => x.CustomerId, "CustomerManagement", "CustomerId");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
