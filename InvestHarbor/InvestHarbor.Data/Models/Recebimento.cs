using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Recebimento : Entities.Recebimento
    {
        public virtual Cliente Cliente { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Recebimento>().ToTable("Recebimentos");
            builder.Entity<Recebimento>().HasKey(x => x.Id);
            builder.Entity<Recebimento>().HasIndex(x => x.Id);
            builder.Entity<Recebimento>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Recebimento>()
                   .Property(x => x.Valor)
                   .HasColumnType("decimal(10, 2)");

            builder.Entity<Recebimento>()
                   .Property(x => x.Observacao)
                   .HasColumnType("varchar(50)");

            builder.Entity<Recebimento>()
                   .HasOne(x => x.Cliente)
                   .WithMany(x => x.Recebimentos)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.ClienteId);
        }
    }
}
