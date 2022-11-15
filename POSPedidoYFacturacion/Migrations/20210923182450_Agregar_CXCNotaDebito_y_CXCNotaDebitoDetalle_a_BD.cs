using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_CXCNotaDebito_y_CXCNotaDebitoDetalle_a_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CXCNotaDebitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CXCTipoNDId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nulo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCNotaDebitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXCNotaDebitos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CXCNotaDebitos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CXCNotaDebitos_CXCTipoND_CXCTipoNDId",
                        column: x => x.CXCTipoNDId,
                        principalTable: "CXCTipoND",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CXCNotaDebitoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCNotaDebitoId = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    BalanceAntes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoAAplicar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceDespues = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCNotaDebitoDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXCNotaDebitoDetalles_CXCNotaDebitos_CXCNotaDebitoId",
                        column: x => x.CXCNotaDebitoId,
                        principalTable: "CXCNotaDebitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CXCNotaDebitoDetalles_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaDebitoDetalles_CXCNotaDebitoId",
                table: "CXCNotaDebitoDetalles",
                column: "CXCNotaDebitoId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaDebitoDetalles_VentaId",
                table: "CXCNotaDebitoDetalles",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaDebitos_ClienteId",
                table: "CXCNotaDebitos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaDebitos_CXCTipoNDId",
                table: "CXCNotaDebitos",
                column: "CXCTipoNDId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaDebitos_UsuarioId",
                table: "CXCNotaDebitos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CXCNotaDebitoDetalles");

            migrationBuilder.DropTable(
                name: "CXCNotaDebitos");
        }
    }
}
