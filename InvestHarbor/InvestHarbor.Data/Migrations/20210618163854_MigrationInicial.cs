using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestHarbor.Data.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carteiras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(45)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: true),
                    Ativa = table.Column<bool>(nullable: false),
                    Bloqueada = table.Column<bool>(nullable: false),
                    LimiteUtilizacao = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteiras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(30)", nullable: true),
                    Sobrenome = table.Column<string>(type: "varchar(50)", nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(8)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(30)", nullable: true),
                    CidadeId = table.Column<Guid>(nullable: false),
                    Bloqueado = table.Column<bool>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    SaldoAtual = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Papeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(10)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(80)", nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    Cotacao = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    UltimaCotacao = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papeis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteContasBancarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    Entidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    Agencia = table.Column<string>(type: "varchar(15)", nullable: true),
                    Conta = table.Column<string>(type: "varchar(15)", nullable: true),
                    Principal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteContasBancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteContasBancarias_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recebimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Conciliado = table.Column<bool>(nullable: false),
                    Observacao = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recebimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recebimentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    EmailVerificado = table.Column<bool>(nullable: false),
                    Senha = table.Column<string>(type: "varchar(15)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Token = table.Column<string>(type: "varchar(100)", nullable: true),
                    UltimoLogin = table.Column<DateTime>(nullable: false),
                    Ip = table.Column<string>(type: "varchar(50)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarteirasPapeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarteiraId = table.Column<Guid>(nullable: false),
                    PapelId = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Bloqueado = table.Column<bool>(nullable: false),
                    PorcentagemCarteira = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    LimitePreco = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
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
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    PapelId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Executada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Papeis_PapelId",
                        column: x => x.PapelId,
                        principalTable: "Papeis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RendimentoDividendo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PapelId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendimentoDividendo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RendimentoDividendo_Papeis_PapelId",
                        column: x => x.PapelId,
                        principalTable: "Papeis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PagamentosRetiradas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    ClienteContaBancariaId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Efetuado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentosRetiradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentosRetiradas_ClienteContasBancarias_ClienteContaBancariaId",
                        column: x => x.ClienteContaBancariaId,
                        principalTable: "ClienteContasBancarias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PagamentosRetiradas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(100)", nullable: true),
                    Admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Acao = table.Column<int>(nullable: false),
                    Tela = table.Column<string>(type: "varchar(100)", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(400)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suportes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(200)", nullable: true),
                    Atendido = table.Column<bool>(nullable: false),
                    Finalizado = table.Column<bool>(nullable: false),
                    Observacao = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suportes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosPermissoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    PermissaoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosPermissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosPermissoes_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuariosPermissoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ordens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarteiraId = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    MovimentacaoId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Executada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordens_Carteiras_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteiras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ordens_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ordens_Movimentacoes_MovimentacaoId",
                        column: x => x.MovimentacaoId,
                        principalTable: "Movimentacoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RendimentosDividendosClientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RendimentoId = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Pago = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendimentosDividendosClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RendimentosDividendosClientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RendimentosDividendosClientes_RendimentoDividendo_RendimentoId",
                        column: x => x.RendimentoId,
                        principalTable: "RendimentoDividendo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientePapeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PapelId = table.Column<Guid>(nullable: false),
                    OrdemId = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
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
                name: "IX_Carteiras_Id",
                table: "Carteiras",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasPapeis_CarteiraId",
                table: "CarteirasPapeis",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasPapeis_Id",
                table: "CarteirasPapeis",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Id",
                table: "Chats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UsuarioId",
                table: "Chats",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteContasBancarias_ClienteId",
                table: "ClienteContasBancarias",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteContasBancarias_Id",
                table: "ClienteContasBancarias",
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

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Id",
                table: "Clientes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_Id",
                table: "Logs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UsuarioId",
                table: "Logs",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_Id",
                table: "Movimentacoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_PapelId",
                table: "Movimentacoes",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_CarteiraId",
                table: "Ordens",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_ClienteId",
                table: "Ordens",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_Id",
                table: "Ordens",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_MovimentacaoId",
                table: "Ordens",
                column: "MovimentacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosRetiradas_ClienteContaBancariaId",
                table: "PagamentosRetiradas",
                column: "ClienteContaBancariaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosRetiradas_ClienteId",
                table: "PagamentosRetiradas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosRetiradas_Id",
                table: "PagamentosRetiradas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Papeis_Id",
                table: "Papeis",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recebimentos_ClienteId",
                table: "Recebimentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Recebimentos_Id",
                table: "Recebimentos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RendimentoDividendo_Id",
                table: "RendimentoDividendo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RendimentoDividendo_PapelId",
                table: "RendimentoDividendo",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_RendimentosDividendosClientes_ClienteId",
                table: "RendimentosDividendosClientes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RendimentosDividendosClientes_Id",
                table: "RendimentosDividendosClientes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RendimentosDividendosClientes_RendimentoId",
                table: "RendimentosDividendosClientes",
                column: "RendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Suportes_Id",
                table: "Suportes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Suportes_UsuarioId",
                table: "Suportes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ClienteId",
                table: "Usuarios",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPermissoes_Id",
                table: "UsuariosPermissoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPermissoes_PermissaoId",
                table: "UsuariosPermissoes",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPermissoes_UsuarioId",
                table: "UsuariosPermissoes",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteirasPapeis");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "ClientePapeis");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "PagamentosRetiradas");

            migrationBuilder.DropTable(
                name: "Recebimentos");

            migrationBuilder.DropTable(
                name: "RendimentosDividendosClientes");

            migrationBuilder.DropTable(
                name: "Suportes");

            migrationBuilder.DropTable(
                name: "UsuariosPermissoes");

            migrationBuilder.DropTable(
                name: "Ordens");

            migrationBuilder.DropTable(
                name: "ClienteContasBancarias");

            migrationBuilder.DropTable(
                name: "RendimentoDividendo");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Carteiras");

            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Papeis");
        }
    }
}
