using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_OrdenDetalleHistorial_a_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdenDetalleHistoriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDetalleHistoriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenDetalleHistoriales_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdenDetalleHistoriales_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDetalleHistoriales_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalleHistoriales_OrdenId",
                table: "OrdenDetalleHistoriales",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalleHistoriales_ProductoId",
                table: "OrdenDetalleHistoriales",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalleHistoriales_UsuarioId",
                table: "OrdenDetalleHistoriales",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenDetalleHistoriales");
        }
    }
}
