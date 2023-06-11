using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_CXPTransacciones_CXPtransanccionDetalles_CXPTransaccionTipos_y_CXPTransaccionTipoDocumentos_a_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CXPTransaccionId",
                table: "CXCTransaccionDetalles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CXPCompraBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXPCompraBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXPCompraBalances_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CXPTransaccionTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXPTransaccionTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CXPTransaccionTipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXPTransaccionTipoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXPTransaccionTipoDocumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXPTransaccionTipoDocumentos_CXPTransaccionTipos_CXPTransaccionTipoId",
                        column: x => x.CXPTransaccionTipoId,
                        principalTable: "CXPTransaccionTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CXPTransacciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuadreId = table.Column<int>(type: "int", nullable: true),
                    SuplidorId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CXPTransaccionTipoId = table.Column<int>(type: "int", nullable: false),
                    CXPTransaccionTipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nulo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXPTransacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXPTransacciones_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CXPTransacciones_Cuadres_CuadreId",
                        column: x => x.CuadreId,
                        principalTable: "Cuadres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CXPTransacciones_CXPTransaccionTipoDocumentos_CXPTransaccionTipoDocumentoId",
                        column: x => x.CXPTransaccionTipoDocumentoId,
                        principalTable: "CXPTransaccionTipoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CXPTransacciones_CXPTransaccionTipos_CXPTransaccionTipoId",
                        column: x => x.CXPTransaccionTipoId,
                        principalTable: "CXPTransaccionTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CXPTransacciones_Suplidores_SuplidorId",
                        column: x => x.SuplidorId,
                        principalTable: "Suplidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CXPTransaccionDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXPTransaccionId = table.Column<int>(type: "int", nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    BalanceAntes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoAAplicar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceDespues = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXPTransaccionDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CXPTransaccionDetalles_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CXPTransaccionDetalles_CXPTransacciones_CXPTransaccionId",
                        column: x => x.CXPTransaccionId,
                        principalTable: "CXPTransacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransaccionDetalles_CXPTransaccionId",
                table: "CXCTransaccionDetalles",
                column: "CXPTransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPCompraBalances_CompraId",
                table: "CXPCompraBalances",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransaccionDetalles_CompraId",
                table: "CXPTransaccionDetalles",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransaccionDetalles_CXPTransaccionId",
                table: "CXPTransaccionDetalles",
                column: "CXPTransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransacciones_CuadreId",
                table: "CXPTransacciones",
                column: "CuadreId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransacciones_CXPTransaccionTipoDocumentoId",
                table: "CXPTransacciones",
                column: "CXPTransaccionTipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransacciones_CXPTransaccionTipoId",
                table: "CXPTransacciones",
                column: "CXPTransaccionTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransacciones_SuplidorId",
                table: "CXPTransacciones",
                column: "SuplidorId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransacciones_UsuarioId",
                table: "CXPTransacciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransaccionTipoDocumentos_CXPTransaccionTipoId",
                table: "CXPTransaccionTipoDocumentos",
                column: "CXPTransaccionTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CXCTransaccionDetalles_CXPTransacciones_CXPTransaccionId",
                table: "CXCTransaccionDetalles",
                column: "CXPTransaccionId",
                principalTable: "CXPTransacciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CXCTransaccionDetalles_CXPTransacciones_CXPTransaccionId",
                table: "CXCTransaccionDetalles");

            migrationBuilder.DropTable(
                name: "CXPCompraBalances");

            migrationBuilder.DropTable(
                name: "CXPTransaccionDetalles");

            migrationBuilder.DropTable(
                name: "CXPTransacciones");

            migrationBuilder.DropTable(
                name: "CXPTransaccionTipoDocumentos");

            migrationBuilder.DropTable(
                name: "CXPTransaccionTipos");

            migrationBuilder.DropIndex(
                name: "IX_CXCTransaccionDetalles_CXPTransaccionId",
                table: "CXCTransaccionDetalles");

            migrationBuilder.DropColumn(
                name: "CXPTransaccionId",
                table: "CXCTransaccionDetalles");
        }
    }
}
