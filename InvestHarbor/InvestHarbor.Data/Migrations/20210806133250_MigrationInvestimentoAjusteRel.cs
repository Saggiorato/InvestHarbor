using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestHarbor.Data.Migrations
{
    public partial class MigrationInvestimentoAjusteRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteirasInvestimentos_Investimento_CarteiraId",
                table: "CarteirasInvestimentos");

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasInvestimentos_InvestimentoId",
                table: "CarteirasInvestimentos",
                column: "InvestimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteirasInvestimentos_Investimento_InvestimentoId",
                table: "CarteirasInvestimentos",
                column: "InvestimentoId",
                principalTable: "Investimento",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteirasInvestimentos_Investimento_InvestimentoId",
                table: "CarteirasInvestimentos");

            migrationBuilder.DropIndex(
                name: "IX_CarteirasInvestimentos_InvestimentoId",
                table: "CarteirasInvestimentos");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteirasInvestimentos_Investimento_CarteiraId",
                table: "CarteirasInvestimentos",
                column: "CarteiraId",
                principalTable: "Investimento",
                principalColumn: "Id");
        }
    }
}
