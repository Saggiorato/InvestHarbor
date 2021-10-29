using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Ordem : Entities.Ordem
    {
        public virtual Carteira Carteira { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Movimentacao Movimentacao { get; set; }
        public virtual List<ClienteInvestimento> Papeis { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Ordem>().ToTable("Ordens");
            builder.Entity<Ordem>().HasKey(x => x.Id);
            builder.Entity<Ordem>().HasIndex(x => x.Id);
            builder.Entity<Ordem>().Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Entity<Ordem>()
                   .HasOne(x => x.Carteira)
                   .WithMany(x => x.Ordens)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.CarteiraId);

            builder.Entity<Ordem>()
                   .HasOne(x => x.Cliente)
                   .WithMany(x => x.Ordens)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.ClienteId);

            builder.Entity<Ordem>()
                   .HasOne(x => x.Movimentacao)
                   .WithMany(x => x.Ordens)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.MovimentacaoId);
        }
    }
}
