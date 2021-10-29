using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class PagamentoRetirada : Entities.PagamentoRetirada
    {
        public virtual Cliente Cliente { get; set; }
        public virtual ClienteContaBancaria ClienteContaBancaria { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<PagamentoRetirada>().ToTable("PagamentosRetiradas");
            builder.Entity<PagamentoRetirada>().HasKey(x => x.Id);
            builder.Entity<PagamentoRetirada>().HasIndex(x => x.Id);
            builder.Entity<PagamentoRetirada>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<PagamentoRetirada>()
                   .Property(x => x.Valor)
                   .HasColumnType("decimal(10, 2)");

            builder.Entity<PagamentoRetirada>()
                   .HasOne(x => x.Cliente)
                   .WithMany(x => x.PagamentosRetiradas)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.ClienteId);

            builder.Entity<PagamentoRetirada>()
                   .HasOne(x => x.ClienteContaBancaria)
                   .WithMany(x => x.PagamentosRetiradas)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.ClienteId);

            builder.Entity<PagamentoRetirada>()
                   .HasOne(x => x.ClienteContaBancaria)
                   .WithMany(x => x.PagamentosRetiradas)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.ClienteContaBancariaId);
        }
    }
}
