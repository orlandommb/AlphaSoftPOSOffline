using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_CXCNotaCredito_y_CXCNotaCreditoDetalle_a_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CXCTipoNC",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CXCNotaCreditos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CXCTipoNCId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nulo = table.Column<bool>(type: "bit", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CXCNotaCreditos_CXCTipoNC_CXCTipoNCId",
                        column: x => x.CXCTipoNCId,
                        principalTable: "CXCTipoNC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CXCNotaCreditoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCNotaCreditoId = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    BalanceAntes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoAAplicar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceDespues = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CXCNotaCreditoDetalles");

            migrationBuilder.DropTable(
                name: "CXCNotaCreditos");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CXCTipoNC",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
