using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class RendimentoDividendoCliente : Entities.RendimentoDividendoCliente
    {
        public RendimentoDividendo RendimentoDividendo { get; set; }
        public Cliente Cliente { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<RendimentoDividendoCliente>().ToTable("RendimentosDividendosClientes");
            builder.Entity<RendimentoDividendoCliente>().HasKey(x => x.Id);
            builder.Entity<RendimentoDividendoCliente>().HasIndex(x => x.Id);
            builder.Entity<RendimentoDividendoCliente>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<RendimentoDividendoCliente>()
                   .Property(x => x.Valor)
                   .HasColumnType("decimal(10, 2)");

            builder.Entity<RendimentoDividendoCliente>()
                   .HasOne(x => x.RendimentoDividendo)
                   .WithMany(x => x.Clientes)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.RendimentoId);

            builder.Entity<RendimentoDividendoCliente>()
                   .HasOne(x => x.Cliente)
                   .WithMany(x => x.RendimentosDividendos)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.ClienteId);

        }
    }
}
