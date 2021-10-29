using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Carteira : Entities.Carteira
    {
        public virtual List<CarteiraInvestimento> InvestimentosCarteira { get; set; }
        public virtual List<Ordem> Ordens { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Carteira>().ToTable("Carteiras");
            builder.Entity<Carteira>().HasKey(x => x.Id);
            builder.Entity<Carteira>().HasIndex(x => x.Id);
            builder.Entity<Carteira>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Carteira>()
                   .Property(x => x.Nome)
                   .HasColumnType("varchar(45)");

            builder.Entity<Carteira>()
                   .Property(x => x.Descricao)
                   .HasColumnType("varchar(300)");

            builder.Entity<Carteira>()
                   .Property(x => x.Valor)
                   .HasColumnType("decimal(10, 2)");
        }
    }
}
