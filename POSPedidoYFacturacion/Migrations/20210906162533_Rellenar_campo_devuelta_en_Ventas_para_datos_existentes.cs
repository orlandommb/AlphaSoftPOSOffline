using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Rellenar_campo_devuelta_en_Ventas_para_datos_existentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    begin 
                        DECLARE @VentaId int;

                        DECLARE CursorDatos CURSOR FOR
                        select Id from Ventas

                        open CursorDatos
                        FETCH CursorDatos INTO @VentaId

                        WHILE (@@FETCH_STATUS = 0)
                            BEGIN
                            update Ventas set MontoDevuelta = (Select Sum(V.MontoEfectivo - V.Total) from Ventas as v where Id = @VentaId) WHERE Id = @VentaId
                            FETCH CursorDatos INTO @VentaId
                            END

                        CLOSE CursorDatos
                        DEALLOCATE CursorDatos
                    END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
