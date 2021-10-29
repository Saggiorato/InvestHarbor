using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class RendimentoDividendo : Entities.RendimentoDividendo
    {
        public Investimento Investimento { get; set; }
        public List<RendimentoDividendoCliente> Clientes { get; set; }
        
        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<RendimentoDividendo>().ToTable("RendimentoDividendo");
            builder.Entity<RendimentoDividendo>().HasKey(x => x.Id);
            builder.Entity<RendimentoDividendo>().HasIndex(x => x.Id);
            builder.Entity<RendimentoDividendo>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<RendimentoDividendo>()
                   .Property(x => x.Valor)
                   .HasColumnType("decimal(10, 2)");

            builder.Entity<RendimentoDividendo>()
                   .HasOne(x => x.Investimento)
                   .WithMany(x => x.RendimentosDividendos)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.InvestimentoId);
        }
    }
}
