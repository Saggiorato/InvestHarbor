using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestHarbor.Data.Migrations
{
    public partial class MigrationPapelInvestimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Papeis_PapelId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_RendimentoDividendo_Papeis_PapelId",
                table: "RendimentoDividendo");

            migrationBuilder.DropTable(
                name: "CarteirasPapeis");

            migrationBuilder.DropTable(
                name: "ClientePapeis");

            migrationBuilder.DropIndex(
                name: "IX_RendimentoDividendo_PapelId",
                table: "RendimentoDividendo");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_PapelId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "PapelId",
                table: "RendimentoDividendo");

            migrationBuilder.DropColumn(
                name: "PapelId",
                table: "Movimentacoes");

            migrationBuilder.AddColumn<Guid>(
                name: "InvestimentoId",
                table: "RendimentoDividendo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InvestimentoId",
                table: "Movimentacoes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CarteirasInvestimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarteiraId = table.Column<Guid>(nullable: false),
                    InvestimentoId = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Bloqueado = table.Column<bool>(nullable: false),
                    PorcentagemCarteira = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    LimitePreco = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteirasInvestimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarteirasInvestimentos_Carteiras_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteiras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarteirasInvestimentos_Papeis_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Papeis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClienteInvestimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InvestimentoId = table.Column<Guid>(nullable: false),
                    OrdemId = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteInvestimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteInvestimentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClienteInvestimentos_Papeis_InvestimentoId",
                        column: x => x.InvestimentoId,
                        principalTable: "Papeis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClienteInvestimentos_Ordens_OrdemId",
                        column: x => x.OrdemId,
                        principalTable: "Ordens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RendimentoDividendo_InvestimentoId",
                table: "RendimentoDividendo",
                column: "InvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_InvestimentoId",
                table: "Movimentacoes",
                column: "InvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasInvestimentos_CarteiraId",
                table: "CarteirasInvestimentos",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasInvestimentos_Id",
                table: "CarteirasInvestimentos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteInvestimentos_ClienteId",
                table: "ClienteInvestimentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteInvestimentos_Id",
                table: "ClienteInvestimentos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteInvestimentos_InvestimentoId",
                table: "ClienteInvestimentos",
                column: "InvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteInvestimentos_OrdemId",
                table: "ClienteInvestimentos",
                column: "OrdemId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Papeis_InvestimentoId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_RendimentoDividendo_Papeis_InvestimentoId",
                table: "RendimentoDividendo");

            migrationBuilder.DropTable(
                name: "CarteirasInvestimentos");

            migrationBuilder.DropTable(
                name: "ClienteInvestimentos");

            migrationBuilder.DropIndex(
                name: "IX_RendimentoDividendo_InvestimentoId",
                table: "RendimentoDividendo");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_InvestimentoId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "InvestimentoId",
                table: "RendimentoDividendo");

            migrationBuilder.DropColumn(
                name: "InvestimentoId",
                table: "Movimentacoes");

            migrationBuilder.AddColumn<Guid>(
                name: "PapelId",
                table: "RendimentoDividendo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PapelId",
                table: "Movimentacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CarteirasPapeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    CarteiraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LimitePreco = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    PapelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PorcentagemCarteira = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteirasPapeis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarteirasPapeis_Carteiras_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteiras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarteirasPapeis_Papeis_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Papeis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientePapeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrdemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PapelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePapeis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientePapeis_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientePapeis_Ordens_OrdemId",
                        column: x => x.OrdemId,
                        principalTable: "Ordens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientePapeis_Papeis_PapelId",
                        column: x => x.PapelId,
                        principalTable: "Papeis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RendimentoDividendo_PapelId",
                table: "RendimentoDividendo",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_PapelId",
                table: "Movimentacoes",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasPapeis_CarteiraId",
                table: "CarteirasPapeis",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasPapeis_Id",
                table: "CarteirasPapeis",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientePapeis_ClienteId",
                table: "ClientePapeis",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientePapeis_Id",
                table: "ClientePapeis",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientePapeis_OrdemId",
                table: "ClientePapeis",
                column: "OrdemId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientePapeis_PapelId",
                table: "ClientePapeis",
                column: "PapelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Papeis_PapelId",
                table: "Movimentacoes",
                column: "PapelId",
                principalTable: "Papeis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RendimentoDividendo_Papeis_PapelId",
                table: "RendimentoDividendo",
                column: "PapelId",
                principalTable: "Papeis",
                principalColumn: "Id");
        }
    }
}
