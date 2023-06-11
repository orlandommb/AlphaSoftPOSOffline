using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_tabla_Clientes_a_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoIdentificacion = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NoIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditoAbierto = table.Column<bool>(type: "bit", nullable: false),
                    LimiteCredito = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
