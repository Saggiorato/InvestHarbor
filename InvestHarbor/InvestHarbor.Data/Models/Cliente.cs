using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Cliente : Entities.Cliente
    {
        public virtual Usuario Usuario { get; set; }
        public virtual List<ClienteContaBancaria> ContasBancarias { get; set; }
        public virtual List<ClienteInvestimento> Investimentos { get; set; }
        public virtual List<Ordem> Ordens { get; set; }
        public virtual List<PagamentoRetirada> PagamentosRetiradas  { get; set; }
        public virtual List<Recebimento> Recebimentos { get; set; }
        public virtual List<RendimentoDividendoCliente> RendimentosDividendos { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Cliente>().ToTable("Clientes");
            builder.Entity<Cliente>().HasKey(x => x.Id);
            builder.Entity<Cliente>().HasIndex(x => x.Id);
            builder.Entity<Cliente>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Cliente>()
                    .Property(x => x.Nome)
                    .HasColumnType("varchar(30)");

            builder.Entity<Cliente>()
                    .Property(x => x.Sobrenome)
                    .HasColumnType("varchar(50)");

            builder.Entity<Cliente>()
                    .Property(x => x.Cpf)
                    .HasColumnType("varchar(11)");

            builder.Entity<Cliente>()
                    .Property(x => x.Telefone)
                    .HasColumnType("varchar(15)");

            builder.Entity<Cliente>()
                    .Property(x => x.Email)
                    .HasColumnType("varchar(50)");

            builder.Entity<Cliente>()
                    .Property(x => x.Endereco)
                    .HasColumnType("varchar(100)");

            builder.Entity<Cliente>()
                    .Property(x => x.Numero)
                    .HasColumnType("varchar(8)");

            builder.Entity<Cliente>()
                    .Property(x => x.Complemento)
                    .HasColumnType("varchar(100)");

            builder.Entity<Cliente>()
                    .Property(x => x.Bairro)
                    .HasColumnType("varchar(30)");

            builder.Entity<Cliente>()
                    .Property(x => x.Bairro)
                    .HasColumnType("varchar(30)");

            builder.Entity<Cliente>()
                    .Property(x => x.SaldoAtual)
                    .HasColumnType("decimal(10,2)");
        }
    }
}
