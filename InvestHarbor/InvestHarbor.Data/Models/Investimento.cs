using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Investimento : Entities.Investimento
    {
        public virtual List<CarteiraInvestimento> Carteiras { get; set; }
        public virtual List<ClienteInvestimento> Clientes { get; set; }
        public virtual List<Movimentacao> Movimentacoes { get; set; }
        public virtual List<RendimentoDividendo> RendimentosDividendos { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Investimento>().ToTable("Investimento");
            builder.Entity<Investimento>().HasKey(x => x.Id);
            builder.Entity<Investimento>().HasIndex(x => x.Id);
            builder.Entity<Investimento>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Investimento>()
                   .Property(x => x.Nome)
                   .HasColumnType("varchar(10)");

            builder.Entity<Investimento>()
                   .Property(x => x.Descricao)
                   .HasColumnType("varchar(80)");

            builder.Entity<Investimento>()
                   .Property(x => x.Cotacao)
                   .HasColumnType("decimal(10, 2)");

            builder.Entity<Investimento>()
                   .Property(x => x.UltimaCotacao)
                   .HasColumnType("decimal(10, 2)");
        }
    }
}
