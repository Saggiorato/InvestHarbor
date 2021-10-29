using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class ClienteContaBancaria : Entities.ClienteContaBancaria
    {
        public virtual Cliente Cliente { get; set; }
        public virtual List<PagamentoRetirada> PagamentosRetiradas { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<ClienteContaBancaria>().ToTable("ClienteContasBancarias");
            builder.Entity<ClienteContaBancaria>().HasKey(x => x.Id);
            builder.Entity<ClienteContaBancaria>().HasIndex(x => x.Id);
            builder.Entity<ClienteContaBancaria>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<ClienteContaBancaria>()
                    .Property(x => x.Entidade)
                    .HasColumnType("varchar(100)");

            builder.Entity<ClienteContaBancaria>()
                    .Property(x => x.Agencia)
                    .HasColumnType("varchar(15)");

            builder.Entity<ClienteContaBancaria>()
                    .Property(x => x.Conta)
                    .HasColumnType("varchar(15)");

            builder.Entity<ClienteContaBancaria>()
                   .HasOne(x => x.Cliente)
                   .WithMany(x => x.ContasBancarias)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.ClienteId);
        }
    }
}
