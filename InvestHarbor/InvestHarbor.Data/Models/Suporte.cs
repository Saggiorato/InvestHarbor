using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Suporte : Entities.Suporte
    {
        public virtual Usuario Usuario { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Suporte>().ToTable("Suportes");
            builder.Entity<Suporte>().HasKey(x => x.Id);
            builder.Entity<Suporte>().HasIndex(x => x.Id);
            builder.Entity<Suporte>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Suporte>()
                   .Property(x => x.Mensagem)
                   .HasColumnType("varchar(200)");

            builder.Entity<Suporte>()
                   .Property(x => x.Observacao)
                   .HasColumnType("varchar(200)");

            builder.Entity<Suporte>()
                   .HasOne(x => x.Usuario)
                   .WithMany(x => x.Suportes)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.UsuarioId);
        }
    }
}
