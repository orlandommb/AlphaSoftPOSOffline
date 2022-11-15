using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_VentaDevolucion_y_VentaDevolucionDetalle_a_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VentaDevoluciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    AlmacenId = table.Column<int>(type: "int", nullable: false),
                    CuadreId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Nulo = table.Column<bool>(type: "bit", nullable: false),
                    Facturado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Impuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaDevoluciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaDevoluciones_Almacenes_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VentaDevoluciones_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VentaDevoluciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VentaDevoluciones_Cuadres_CuadreId",
                        column: x => x.CuadreId,
                        principalTable: "Cuadres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VentaDevoluciones_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VentaDevoluciones_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VentaDevoluciones_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VentaDevolucionDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaDevolucionId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Impuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaDevolucionDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaDevolucionDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VentaDevolucionDetalles_VentaDevoluciones_VentaDevolucionId",
                        column: x => x.VentaDevolucionId,
                        principalTable: "VentaDevoluciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentaDevolucionDetalles_ProductoId",
                table: "VentaDevolucionDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDevolucionDetalles_VentaDevolucionId",
                table: "VentaDevolucionDetalles",
                column: "VentaDevolucionId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDevoluciones_AlmacenId",
                table: "VentaDevoluciones",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDevoluciones_ClienteId",
                table: "VentaDevoluciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDevoluciones_CuadreId",
                table: "VentaDevoluciones",
                column: "CuadreId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDevoluciones_EmpresaId",
                table: "VentaDevoluciones",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDevoluciones_SucursalId",
                table: "VentaDevoluciones",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDevoluciones_UsuarioId",
                table: "VentaDevoluciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDevoluciones_VentaId",
                table: "VentaDevoluciones",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentaDevolucionDetalles");

            migrationBuilder.DropTable(
                name: "VentaDevoluciones");
        }
    }
}
