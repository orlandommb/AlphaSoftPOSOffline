using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_AjusteInventarioTipos_AjustesInventario_y_AjusteInventarioDetalles_a_la_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AjusteInventarioTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjusteInventarioTipos", x => x.Id);
                });

            migrationBuilder.Sql(@"

            if not exists (select * from AjusteInventarioTipos where Nombre = 'Entrada')
            begin
                insert into AjusteInventarioTipos (Nombre, Descripcion) values ('Entrada', 'Entrada de productos');
            end

            if not exists (select * from AjusteInventarioTipos where Nombre = 'Salida')
            begin
                insert into AjusteInventarioTipos (Nombre, Descripcion) values ('Salida', 'Salida de productos');
            end

            ");

            migrationBuilder.CreateTable(
                name: "AjustesInventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AjusteInventarioTipoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    AlmacenId = table.Column<int>(type: "int", nullable: false),
                    Nulo = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjustesInventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AjustesInventario_AjusteInventarioTipos_AjusteInventarioTipoId",
                        column: x => x.AjusteInventarioTipoId,
                        principalTable: "AjusteInventarioTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AjustesInventario_Almacenes_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AjustesInventario_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AjustesInventario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AjustesInventario_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AjusteInventarioDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AjusteInventarioId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjusteInventarioDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AjusteInventarioDetalles_AjustesInventario_AjusteInventarioId",
                        column: x => x.AjusteInventarioId,
                        principalTable: "AjustesInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AjusteInventarioDetalles_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarioDetalles_AjusteInventarioId",
                table: "AjusteInventarioDetalles",
                column: "AjusteInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarioDetalles_ProductosId",
                table: "AjusteInventarioDetalles",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventario_AjusteInventarioTipoId",
                table: "AjustesInventario",
                column: "AjusteInventarioTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventario_AlmacenId",
                table: "AjustesInventario",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventario_EmpresaId",
                table: "AjustesInventario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventario_SucursalId",
                table: "AjustesInventario",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventario_UsuarioId",
                table: "AjustesInventario",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AjusteInventarioDetalles");

            migrationBuilder.DropTable(
                name: "AjustesInventario");

            migrationBuilder.DropTable(
                name: "AjusteInventarioTipos");
        }
    }
}
