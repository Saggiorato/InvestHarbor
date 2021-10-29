using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestHarbor.Data.Migrations
{
    public partial class MigrationInvestimentoPapel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteirasInvestimentos_Papeis_CarteiraId",
                table: "CarteirasInvestimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClienteInvestimentos_Papeis_InvestimentoId",
                table: "ClienteInvestimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Papeis_InvestimentoId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_RendimentoDividendo_Papeis_InvestimentoId",
                table: "RendimentoDividendo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Papeis",
                table: "Papeis");

            migrationBuilder.RenameTable(
                name: "Papeis",
                newName: "Investimento");

            migrationBuilder.RenameIndex(
                name: "IX_Papeis_Id",
                table: "Investimento",
                newName: "IX_Investimento_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investimento",
                table: "Investimento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteirasInvestimentos_Investimento_CarteiraId",
                table: "CarteirasInvestimentos",
                column: "CarteiraId",
                principalTable: "Investimento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteInvestimentos_Investimento_InvestimentoId",
                table: "ClienteInvestimentos",
                column: "InvestimentoId",
                principalTable: "Investimento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Investimento_InvestimentoId",
                table: "Movimentacoes",
                column: "InvestimentoId",
                principalTable: "Investimento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RendimentoDividendo_Investimento_InvestimentoId",
                table: "RendimentoDividendo",
                column: "InvestimentoId",
                principalTable: "Investimento",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteirasInvestimentos_Investimento_CarteiraId",
                table: "CarteirasInvestimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClienteInvestimentos_Investimento_InvestimentoId",
                table: "ClienteInvestimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Investimento_InvestimentoId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_RendimentoDividendo_Investimento_InvestimentoId",
                table: "RendimentoDividendo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investimento",
                table: "Investimento");

            migrationBuilder.RenameTable(
                name: "Investimento",
                newName: "Papeis");

            migrationBuilder.RenameIndex(
                name: "IX_Investimento_Id",
                table: "Papeis",
                newName: "IX_Papeis_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Papeis",
                table: "Papeis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteirasInvestimentos_Papeis_CarteiraId",
                table: "CarteirasInvestimentos",
                column: "CarteiraId",
                principalTable: "Papeis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteInvestimentos_Papeis_InvestimentoId",
                table: "ClienteInvestimentos",
                column: "InvestimentoId",
                principalTable: "Papeis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Papeis_InvestimentoId",
                table: "Movimentacoes",
                column: "InvestimentoId",
                principalTable: "Papeis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RendimentoDividendo_Papeis_InvestimentoId",
                table: "RendimentoDividendo",
                column: "InvestimentoId",
                principalTable: "Papeis",
                principalColumn: "Id");
        }
    }
}
