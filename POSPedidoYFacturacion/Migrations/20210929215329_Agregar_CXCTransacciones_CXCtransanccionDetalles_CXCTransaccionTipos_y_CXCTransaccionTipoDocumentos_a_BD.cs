using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_CXCTransacciones_CXCtransanccionDetalles_CXCTransaccionTipos_y_CXCTransaccionTipoDocumentos_a_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CXCTransaccionTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCTransaccionTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CXCTransaccionTipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCTransaccionTipoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCTransaccionTipoDocumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXCTransaccionTipoDocumentos_CXCTransaccionTipos_CXCTransaccionTipoId",
                        column: x => x.CXCTransaccionTipoId,
                        principalTable: "CXCTransaccionTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CXCTransacciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CXCTransaccionTipoId = table.Column<int>(type: "int", nullable: false),
                    CXCTransaccionTipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nulo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCTransacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXCTransacciones_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CXCTransacciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CXCTransacciones_CXCTransaccionTipoDocumentos_CXCTransaccionTipoDocumentoId",
                        column: x => x.CXCTransaccionTipoDocumentoId,
                        principalTable: "CXCTransaccionTipoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CXCTransacciones_CXCTransaccionTipos_CXCTransaccionTipoId",
                        column: x => x.CXCTransaccionTipoId,
                        principalTable: "CXCTransaccionTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CXCTransaccionDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCTransaccionId = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    BalanceAntes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoAAplicar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceDespues = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCTransaccionDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXCTransaccionDetalles_CXCTransacciones_CXCTransaccionId",
                        column: x => x.CXCTransaccionId,
                        principalTable: "CXCTransacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CXCTransaccionDetalles_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransaccionDetalles_CXCTransaccionId",
                table: "CXCTransaccionDetalles",
                column: "CXCTransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransaccionDetalles_VentaId",
                table: "CXCTransaccionDetalles",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransacciones_ClienteId",
                table: "CXCTransacciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransacciones_CXCTransaccionTipoDocumentoId",
                table: "CXCTransacciones",
                column: "CXCTransaccionTipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransacciones_CXCTransaccionTipoId",
                table: "CXCTransacciones",
                column: "CXCTransaccionTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransacciones_UsuarioId",
                table: "CXCTransacciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransaccionTipoDocumentos_CXCTransaccionTipoId",
                table: "CXCTransaccionTipoDocumentos",
                column: "CXCTransaccionTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CXCTransaccionDetalles");

            migrationBuilder.DropTable(
                name: "CXCTransacciones");

            migrationBuilder.DropTable(
                name: "CXCTransaccionTipoDocumentos");

            migrationBuilder.DropTable(
                name: "CXCTransaccionTipos");
        }
    }
}
