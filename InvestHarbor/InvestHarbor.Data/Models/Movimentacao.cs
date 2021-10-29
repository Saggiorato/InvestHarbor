using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Movimentacao : Entities.Movimentacao
    {
        public Investimento Investimento { get; set; }
        public virtual List<Ordem> Ordens { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Movimentacao>().ToTable("Movimentacoes");
            builder.Entity<Movimentacao>().HasKey(x => x.Id);
            builder.Entity<Movimentacao>().HasIndex(x => x.Id);
            builder.Entity<Movimentacao>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Movimentacao>()
                   .Property(x => x.Valor)
                   .HasColumnType("decimal(10, 2)");

            builder.Entity<Movimentacao>()
                   .HasOne(x => x.Investimento)
                   .WithMany(x => x.Movimentacoes)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.InvestimentoId);
        }
    }
}
