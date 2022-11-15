using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_Impuestos_y_ImpuestoTipos_junto_con_Scripts_de_Insercion_a_la_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Impuestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impuestos", x => x.Id);
                });

            migrationBuilder.Sql(@"
            
            if not exists (select * from Impuestos where Nombre = 'ITBIS 18%')
            begin
                insert into Impuestos (Nombre, Valor) values ('ITBIS 18%', 18.00)
            end
            
            if not exists (select * from Impuestos where Nombre = 'ITBIS 16%')
            begin
                insert into Impuestos (Nombre, Valor) values ('ITBIS 16%', 16.00)
            end
            
            ");

            migrationBuilder.CreateTable(
                name: "ImpuestoTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpuestoTipos", x => x.Id);
                });


            migrationBuilder.Sql(@"
            
            if not exists (select * from ImpuestoTipos where Nombre = 'Exento')
            begin
                insert into ImpuestoTipos (Nombre, Descripcion) values ('Exento', 'No grava Impuesto')
            end

            if not exists (select * from ImpuestoTipos where Nombre = 'Sumado')
            begin
                insert into ImpuestoTipos (Nombre, Descripcion) values ('Sumado', 'Impuesto sumado al precio')
            end
            
            if not exists (select * from ImpuestoTipos where Nombre = 'Incluido')
            begin
                insert into ImpuestoTipos (Nombre, Descripcion) values ('Incluido', 'Impuesto incluido en el precio')
            end
            
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impuestos");

            migrationBuilder.DropTable(
                name: "ImpuestoTipos");
        }
    }
}
