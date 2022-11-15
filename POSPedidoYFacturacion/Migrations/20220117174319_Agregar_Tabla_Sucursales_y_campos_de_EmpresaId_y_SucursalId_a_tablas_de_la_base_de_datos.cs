using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_Tabla_Sucursales_y_campos_de_EmpresaId_y_SucursalId_a_tablas_de_la_base_de_datos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sucursales_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

                migrationBuilder.Sql(
                    @"
                    if not exists (select * from Sucursales)
                    begin
                        if not exists (select * from Empresa)
                        BEGIN
                            insert into Empresa (Nombre, Telefono, Direccion, Logo, UsarPOSRestaurant, ImprimirLogoEnFactura, ImprimirLogoEnOrden, MontoMinimoDelivery, TipoOrdenPredeterminada, FechaVencimientoServicio)values ('Nombre Ejemplo', '809-587-2222', 'av. duarte', '', 0, 0, 0, 0.00, 3, (SELECT DATEADD(MONTH, 1, GETDATE())))
                        END
                        INSERT INTO Sucursales (EmpresaId, Nombre) values ((select Id from Empresa), 'Principal')
                    end
                    "
                );

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "SubCategorias",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "SubCategorias",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Mesas",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Mesas",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "CXPTransaccionTipoDocumentos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "CXPTransaccionTipoDocumentos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "CXPTransacciones",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "CXPTransacciones",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "CXCTransaccionTipoDocumentos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "CXCTransaccionTipoDocumentos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "CXCTransacciones",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "CXCTransacciones",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Cuadres",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Cuadres",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Areas",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Areas",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Almacenes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Almacenes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EmpresaId",
                table: "Ventas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_SucursalId",
                table: "Ventas",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategorias_EmpresaId",
                table: "SubCategorias",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategorias_SucursalId",
                table: "SubCategorias",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_EmpresaId",
                table: "Productos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SucursalId",
                table: "Productos",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EmpresaId",
                table: "Ordenes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_SucursalId",
                table: "Ordenes",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_EmpresaId",
                table: "Mesas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_SucursalId",
                table: "Mesas",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransaccionTipoDocumentos_EmpresaId",
                table: "CXPTransaccionTipoDocumentos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransaccionTipoDocumentos_SucursalId",
                table: "CXPTransaccionTipoDocumentos",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransacciones_EmpresaId",
                table: "CXPTransacciones",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_CXPTransacciones_SucursalId",
                table: "CXPTransacciones",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransaccionTipoDocumentos_EmpresaId",
                table: "CXCTransaccionTipoDocumentos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransaccionTipoDocumentos_SucursalId",
                table: "CXCTransaccionTipoDocumentos",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransacciones_EmpresaId",
                table: "CXCTransacciones",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransacciones_SucursalId",
                table: "CXCTransacciones",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuadres_EmpresaId",
                table: "Cuadres",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuadres_SucursalId",
                table: "Cuadres",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_EmpresaId",
                table: "Compras",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_SucursalId",
                table: "Compras",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EmpresaId",
                table: "Clientes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_SucursalId",
                table: "Clientes",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_EmpresaId",
                table: "Categorias",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_SucursalId",
                table: "Categorias",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EmpresaId",
                table: "Areas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_SucursalId",
                table: "Areas",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Almacenes_EmpresaId",
                table: "Almacenes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Almacenes_SucursalId",
                table: "Almacenes",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_EmpresaId",
                table: "Sucursales",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Almacenes_Empresa_EmpresaId",
                table: "Almacenes",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Almacenes_Sucursales_SucursalId",
                table: "Almacenes",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Empresa_EmpresaId",
                table: "Areas",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Sucursales_SucursalId",
                table: "Areas",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Empresa_EmpresaId",
                table: "Categorias",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Sucursales_SucursalId",
                table: "Categorias",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresa_EmpresaId",
                table: "Clientes",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Sucursales_SucursalId",
                table: "Clientes",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Empresa_EmpresaId",
                table: "Compras",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Sucursales_SucursalId",
                table: "Compras",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuadres_Empresa_EmpresaId",
                table: "Cuadres",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuadres_Sucursales_SucursalId",
                table: "Cuadres",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CXCTransacciones_Empresa_EmpresaId",
                table: "CXCTransacciones",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CXCTransacciones_Sucursales_SucursalId",
                table: "CXCTransacciones",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CXCTransaccionTipoDocumentos_Empresa_EmpresaId",
                table: "CXCTransaccionTipoDocumentos",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CXCTransaccionTipoDocumentos_Sucursales_SucursalId",
                table: "CXCTransaccionTipoDocumentos",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CXPTransacciones_Empresa_EmpresaId",
                table: "CXPTransacciones",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CXPTransacciones_Sucursales_SucursalId",
                table: "CXPTransacciones",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CXPTransaccionTipoDocumentos_Empresa_EmpresaId",
                table: "CXPTransaccionTipoDocumentos",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CXPTransaccionTipoDocumentos_Sucursales_SucursalId",
                table: "CXPTransaccionTipoDocumentos",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Mesas_Empresa_EmpresaId",
                table: "Mesas",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Mesas_Sucursales_SucursalId",
                table: "Mesas",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Empresa_EmpresaId",
                table: "Ordenes",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Sucursales_SucursalId",
                table: "Ordenes",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Empresa_EmpresaId",
                table: "Productos",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Sucursales_SucursalId",
                table: "Productos",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategorias_Empresa_EmpresaId",
                table: "SubCategorias",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategorias_Sucursales_SucursalId",
                table: "SubCategorias",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Empresa_EmpresaId",
                table: "Ventas",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Sucursales_SucursalId",
                table: "Ventas",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Almacenes_Empresa_EmpresaId",
                table: "Almacenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Almacenes_Sucursales_SucursalId",
                table: "Almacenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Empresa_EmpresaId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Sucursales_SucursalId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Empresa_EmpresaId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Sucursales_SucursalId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresa_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Sucursales_SucursalId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Empresa_EmpresaId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Sucursales_SucursalId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuadres_Empresa_EmpresaId",
                table: "Cuadres");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuadres_Sucursales_SucursalId",
                table: "Cuadres");

            migrationBuilder.DropForeignKey(
                name: "FK_CXCTransacciones_Empresa_EmpresaId",
                table: "CXCTransacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_CXCTransacciones_Sucursales_SucursalId",
                table: "CXCTransacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_CXCTransaccionTipoDocumentos_Empresa_EmpresaId",
                table: "CXCTransaccionTipoDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_CXCTransaccionTipoDocumentos_Sucursales_SucursalId",
                table: "CXCTransaccionTipoDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_CXPTransacciones_Empresa_EmpresaId",
                table: "CXPTransacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_CXPTransacciones_Sucursales_SucursalId",
                table: "CXPTransacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_CXPTransaccionTipoDocumentos_Empresa_EmpresaId",
                table: "CXPTransaccionTipoDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_CXPTransaccionTipoDocumentos_Sucursales_SucursalId",
                table: "CXPTransaccionTipoDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Mesas_Empresa_EmpresaId",
                table: "Mesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mesas_Sucursales_SucursalId",
                table: "Mesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Empresa_EmpresaId",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Sucursales_SucursalId",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Empresa_EmpresaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Sucursales_SucursalId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategorias_Empresa_EmpresaId",
                table: "SubCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategorias_Sucursales_SucursalId",
                table: "SubCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Empresa_EmpresaId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Sucursales_SucursalId",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_EmpresaId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_SucursalId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_SubCategorias_EmpresaId",
                table: "SubCategorias");

            migrationBuilder.DropIndex(
                name: "IX_SubCategorias_SucursalId",
                table: "SubCategorias");

            migrationBuilder.DropIndex(
                name: "IX_Productos_EmpresaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_SucursalId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_EmpresaId",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_SucursalId",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Mesas_EmpresaId",
                table: "Mesas");

            migrationBuilder.DropIndex(
                name: "IX_Mesas_SucursalId",
                table: "Mesas");

            migrationBuilder.DropIndex(
                name: "IX_CXPTransaccionTipoDocumentos_EmpresaId",
                table: "CXPTransaccionTipoDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_CXPTransaccionTipoDocumentos_SucursalId",
                table: "CXPTransaccionTipoDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_CXPTransacciones_EmpresaId",
                table: "CXPTransacciones");

            migrationBuilder.DropIndex(
                name: "IX_CXPTransacciones_SucursalId",
                table: "CXPTransacciones");

            migrationBuilder.DropIndex(
                name: "IX_CXCTransaccionTipoDocumentos_EmpresaId",
                table: "CXCTransaccionTipoDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_CXCTransaccionTipoDocumentos_SucursalId",
                table: "CXCTransaccionTipoDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_CXCTransacciones_EmpresaId",
                table: "CXCTransacciones");

            migrationBuilder.DropIndex(
                name: "IX_CXCTransacciones_SucursalId",
                table: "CXCTransacciones");

            migrationBuilder.DropIndex(
                name: "IX_Cuadres_EmpresaId",
                table: "Cuadres");

            migrationBuilder.DropIndex(
                name: "IX_Cuadres_SucursalId",
                table: "Cuadres");

            migrationBuilder.DropIndex(
                name: "IX_Compras_EmpresaId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_SucursalId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_SucursalId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_EmpresaId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_SucursalId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Areas_EmpresaId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_SucursalId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Almacenes_EmpresaId",
                table: "Almacenes");

            migrationBuilder.DropIndex(
                name: "IX_Almacenes_SucursalId",
                table: "Almacenes");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "SubCategorias");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "SubCategorias");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Mesas");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Mesas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "CXPTransaccionTipoDocumentos");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "CXPTransaccionTipoDocumentos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "CXPTransacciones");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "CXPTransacciones");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "CXCTransaccionTipoDocumentos");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "CXCTransaccionTipoDocumentos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "CXCTransacciones");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "CXCTransacciones");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Cuadres");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Cuadres");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Almacenes");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Almacenes");
        }
    }
}
