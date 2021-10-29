using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestHarbor.Data.Migrations
{
    public partial class MigrationAjusteUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Clientes");
        }
    }
}
