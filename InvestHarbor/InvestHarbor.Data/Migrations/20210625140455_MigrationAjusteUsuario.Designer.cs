﻿// <auto-generated />
using System;
using InvestHarbor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvestHarbor.Data.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210625140455_MigrationAjusteUsuario")]
    partial class MigrationAjusteUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvestHarbor.Data.Models.Carteira", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativa")
                        .HasColumnType("bit");

                    b.Property<bool>("Bloqueada")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(300)");

                    b.Property<int>("LimiteUtilizacao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(45)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Carteiras");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.CarteiraPapel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<Guid>("CarteiraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("LimitePreco")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<Guid>("PapelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PorcentagemCarteira")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.HasIndex("Id");

                    b.ToTable("CarteirasPapeis");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensagem")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(8)");

                    b.Property<decimal>("SaldoAtual")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.ClienteContaBancaria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Agencia")
                        .HasColumnType("varchar(15)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Conta")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Entidade")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Principal")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Id");

                    b.ToTable("ClienteContasBancarias");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.ClientePapel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrdemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PapelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Id");

                    b.HasIndex("OrdemId");

                    b.HasIndex("PapelId");

                    b.ToTable("ClientePapeis");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Acao")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Tela")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Movimentacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Executada")
                        .HasColumnType("bit");

                    b.Property<Guid>("PapelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("PapelId");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Ordem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarteiraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Executada")
                        .HasColumnType("bit");

                    b.Property<Guid>("MovimentacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Id");

                    b.HasIndex("MovimentacaoId");

                    b.ToTable("Ordens");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.PagamentoRetirada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteContaBancariaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Efetuado")
                        .HasColumnType("bit");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteContaBancariaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Id");

                    b.ToTable("PagamentosRetiradas");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Papel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cotacao")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<decimal>("UltimaCotacao")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Papeis");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Permissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Recebimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Conciliado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Id");

                    b.ToTable("Recebimentos");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.RendimentoDividendo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PapelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("PapelId");

                    b.ToTable("RendimentoDividendo");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.RendimentoDividendoCliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.Property<Guid>("RendimentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Id");

                    b.HasIndex("RendimentoId");

                    b.ToTable("RendimentosDividendosClientes");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Suporte", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Atendido")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<string>("Mensagem")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Suportes");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EmailVerificado")
                        .HasColumnType("bit");

                    b.Property<string>("Ip")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UltimoLogin")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.UsuarioPermissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("PermissaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosPermissoes");
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.CarteiraPapel", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Carteira", "Carteira")
                        .WithMany("Papeis")
                        .HasForeignKey("CarteiraId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InvestHarbor.Data.Models.Papel", "Papel")
                        .WithMany("Carteiras")
                        .HasForeignKey("CarteiraId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Chat", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Usuario", "Usuario")
                        .WithMany("Chats")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.ClienteContaBancaria", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Cliente", "Cliente")
                        .WithMany("ContasBancarias")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.ClientePapel", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Cliente", "Cliente")
                        .WithMany("Papeis")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InvestHarbor.Data.Models.Ordem", "Ordem")
                        .WithMany("Papeis")
                        .HasForeignKey("OrdemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InvestHarbor.Data.Models.Papel", "Papel")
                        .WithMany("Clientes")
                        .HasForeignKey("PapelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Log", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Usuario", "Usuario")
                        .WithMany("Logs")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Movimentacao", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Papel", "Papel")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("PapelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Ordem", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Carteira", "Carteira")
                        .WithMany("Ordens")
                        .HasForeignKey("CarteiraId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InvestHarbor.Data.Models.Cliente", "Cliente")
                        .WithMany("Ordens")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InvestHarbor.Data.Models.Movimentacao", "Movimentacao")
                        .WithMany("Ordens")
                        .HasForeignKey("MovimentacaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.PagamentoRetirada", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.ClienteContaBancaria", "ClienteContaBancaria")
                        .WithMany("PagamentosRetiradas")
                        .HasForeignKey("ClienteContaBancariaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InvestHarbor.Data.Models.Cliente", "Cliente")
                        .WithMany("PagamentosRetiradas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Recebimento", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Cliente", "Cliente")
                        .WithMany("Recebimentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.RendimentoDividendo", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Papel", "Papel")
                        .WithMany("RendimentosDividendos")
                        .HasForeignKey("PapelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.RendimentoDividendoCliente", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Cliente", "Cliente")
                        .WithMany("RendimentosDividendos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InvestHarbor.Data.Models.RendimentoDividendo", "RendimentoDividendo")
                        .WithMany("Clientes")
                        .HasForeignKey("RendimentoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Suporte", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Usuario", "Usuario")
                        .WithMany("Suportes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.Usuario", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Cliente", "Cliente")
                        .WithOne("Usuario")
                        .HasForeignKey("InvestHarbor.Data.Models.Usuario", "ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestHarbor.Data.Models.UsuarioPermissao", b =>
                {
                    b.HasOne("InvestHarbor.Data.Models.Permissao", "Permissao")
                        .WithMany("Usuarios")
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InvestHarbor.Data.Models.Usuario", "Usuario")
                        .WithMany("Permissoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
