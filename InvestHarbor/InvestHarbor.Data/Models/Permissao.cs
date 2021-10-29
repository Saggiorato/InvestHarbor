using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Permissao : Entities.Permissao
    {
        public virtual List<UsuarioPermissao> Usuarios { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Permissao>().ToTable("Permissoes");
            builder.Entity<Permissao>().HasKey(x => x.Id);
            builder.Entity<Permissao>().HasIndex(x => x.Id);
            builder.Entity<Permissao>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Permissao>()
                   .Property(x => x.Descricao)
                   .HasColumnType("varchar(40)");
        }
    }
}
