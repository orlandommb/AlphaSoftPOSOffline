﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_Campo_PorcentajeDescuento_a_CompraDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeDescuento",
                table: "CompraDetalles",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentajeDescuento",
                table: "CompraDetalles");
        }
    }
}
