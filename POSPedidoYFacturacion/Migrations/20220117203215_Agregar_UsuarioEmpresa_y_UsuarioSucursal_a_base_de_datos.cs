using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_UsuarioEmpresa_y_UsuarioSucursal_a_base_de_datos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioEmpresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresas_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresas_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSucursales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SucursalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSucursales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioSucursales_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsuarioSucursales_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql(
                @"

                    begin 
                        DECLARE @UsuarioId nvarchar(450);

                        DECLARE CursorDatos CURSOR FOR
                        select Id from AspNetUsers

                        open CursorDatos
                        FETCH CursorDatos INTO @UsuarioId

                        WHILE (@@FETCH_STATUS = 0)
                            BEGIN
                                if not exists (select * from UsuarioEmpresas)
                                begin
                                    insert into UsuarioEmpresas (Id, UsuarioId, EmpresaId) values (NEWID(), @UsuarioId , 1)

                                    insert into UsuarioSucursales (Id, UsuarioId, SucursalId) values (NEWID(), @UsuarioId, 1)
                                END                            
                                FETCH CursorDatos INTO @UsuarioId
                            END

                        CLOSE CursorDatos
                        DEALLOCATE CursorDatos
                    END


                "
            );

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresas_EmpresaId",
                table: "UsuarioEmpresas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresas_UsuarioId",
                table: "UsuarioEmpresas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSucursales_SucursalId",
                table: "UsuarioSucursales",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSucursales_UsuarioId",
                table: "UsuarioSucursales",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioEmpresas");

            migrationBuilder.DropTable(
                name: "UsuarioSucursales");
        }
    }
}
