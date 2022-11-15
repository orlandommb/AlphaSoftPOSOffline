using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_TpoCompra_a_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCompras", x => x.Id);
                });

            migrationBuilder.Sql(@"

                if not exists (select * from TipoCompras where Nombre = 'Bienes')
                BEGIN
                insert into TipoCompras values ('Bienes');
                END
                
                if not exists (select * from TipoCompras where Nombre = 'Servicios')
                BEGIN
                insert into TipoCompras values ('Servicios');
                END
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoCompras");
        }
    }
}
