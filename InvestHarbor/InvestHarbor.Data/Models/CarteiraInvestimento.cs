using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class CarteiraInvestimento : Entities.CarteiraInvestimento
    {
        public virtual Carteira Carteira { get; set; }
        public virtual Investimento Investimento { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<CarteiraInvestimento>().ToTable("CarteirasInvestimentos");
            builder.Entity<CarteiraInvestimento>().HasKey(x => x.Id);
            builder.Entity<CarteiraInvestimento>().HasIndex(x => x.Id);
            builder.Entity<CarteiraInvestimento>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<CarteiraInvestimento>()
                   .Property(x => x.PorcentagemCarteira)
                   .HasColumnType("decimal(10, 2)");

            builder.Entity<CarteiraInvestimento>()
                   .Property(x => x.LimitePreco)
                   .HasColumnType("decimal(10, 2)");

            builder.Entity<CarteiraInvestimento>()
                   .HasOne(x => x.Carteira)
                   .WithMany(x => x.InvestimentosCarteira)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.CarteiraId);

            builder.Entity<CarteiraInvestimento>()
                   .HasOne(x => x.Investimento)
                   .WithMany(x => x.Carteiras)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.InvestimentoId);
        }
    }
}
