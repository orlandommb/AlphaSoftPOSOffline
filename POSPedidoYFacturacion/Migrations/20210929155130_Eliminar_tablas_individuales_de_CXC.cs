using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Eliminar_tablas_individuales_de_CXC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CXCNotaCreditoDetalles");

            migrationBuilder.DropTable(
                name: "CXCNotaDebitoDetalles");

            migrationBuilder.DropTable(
                name: "CXCNotaCreditos");

            migrationBuilder.DropTable(
                name: "CXCNotaDebitos");

            migrationBuilder.DropTable(
                name: "CXCTipoNC");

            migrationBuilder.DropTable(
                name: "CXCTipoND");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CXCTipoNC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaNCF = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCTipoNC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CXCTipoND",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCTipoND", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CXCNotaCreditos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCTipoNCId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nulo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCNotaCreditos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXCNotaCreditos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CXCNotaCreditos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CXCNotaCreditos_CXCTipoNC_CXCTipoNCId",
                        column: x => x.CXCTipoNCId,
                        principalTable: "CXCTipoNC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CXCNotaDebitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCTipoNDId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nulo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CXCNotaDebitos_CXCTipoND_CXCTipoNDId",
                        column: x => x.CXCTipoNDId,
                        principalTable: "CXCTipoND",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CXCNotaCreditoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalanceAntes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceDespues = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CXCNotaCreditoId = table.Column<int>(type: "int", nullable: false),
                    MontoAAplicar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCNotaCreditoDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXCNotaCreditoDetalles_CXCNotaCreditos_CXCNotaCreditoId",
                        column: x => x.CXCNotaCreditoId,
                        principalTable: "CXCNotaCreditos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CXCNotaCreditoDetalles_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CXCNotaDebitoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalanceAntes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceDespues = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CXCNotaDebitoId = table.Column<int>(type: "int", nullable: false),
                    MontoAAplicar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCNotaDebitoDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXCNotaDebitoDetalles_CXCNotaDebitos_CXCNotaDebitoId",
                        column: x => x.CXCNotaDebitoId,
                        principalTable: "CXCNotaDebitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CXCNotaDebitoDetalles_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaCreditoDetalles_CXCNotaCreditoId",
                table: "CXCNotaCreditoDetalles",
                column: "CXCNotaCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaCreditoDetalles_VentaId",
                table: "CXCNotaCreditoDetalles",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaCreditos_ClienteId",
                table: "CXCNotaCreditos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaCreditos_CXCTipoNCId",
                table: "CXCNotaCreditos",
                column: "CXCTipoNCId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCNotaCreditos_UsuarioId",
                table: "CXCNotaCreditos",
                column: "UsuarioId");

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
    }
}
