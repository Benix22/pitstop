using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManagementAPI.Migrations
{
    public class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarifa",
                columns: table => new
                {
                    TarifaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Grupo = table.Column<string>(nullable: false),
                    Dias = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifa", x => x.TarifaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarifa");
        }
    }
}
