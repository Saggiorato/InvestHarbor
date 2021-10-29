using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class ClienteInvestimento : Entities.ClienteInvestimento
    {
        public virtual Cliente Cliente { get; set; }
        public virtual Investimento Investimento { get; set; }
        public virtual Ordem Ordem { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<ClienteInvestimento>().ToTable("ClienteInvestimentos");
            builder.Entity<ClienteInvestimento>().HasKey(x => x.Id);
            builder.Entity<ClienteInvestimento>().HasIndex(x => x.Id);
            builder.Entity<ClienteInvestimento>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<ClienteInvestimento>()
                    .Property(x => x.Valor)
                    .HasColumnType("decimal(10,2)");

            builder.Entity<ClienteInvestimento>()
                   .HasOne(x => x.Cliente)
                   .WithMany(x => x.Investimentos)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.ClienteId);

            builder.Entity<ClienteInvestimento>()
                   .HasOne(x => x.Investimento)
                   .WithMany(x => x.Clientes)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.InvestimentoId);

            builder.Entity<ClienteInvestimento>()
                   .HasOne(x => x.Ordem)
                   .WithMany(x => x.Papeis)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.OrdemId);
        }
    }
}
