using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class UsuarioPermissao : Entities.UsuarioPermissao
    {
        public Usuario Usuario { get; set; }
        public Permissao Permissao { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<UsuarioPermissao>().ToTable("UsuariosPermissoes");
            builder.Entity<UsuarioPermissao>().HasKey(x => x.Id);
            builder.Entity<UsuarioPermissao>().HasIndex(x => x.Id);
            builder.Entity<UsuarioPermissao>().Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Entity<UsuarioPermissao>()
                   .HasOne(x => x.Usuario)
                   .WithMany(x => x.Permissoes)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.UsuarioId);

            builder.Entity<UsuarioPermissao>()
                   .HasOne(x => x.Permissao)
                   .WithMany(x => x.Usuarios)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.PermissaoId);
        }
    }
}
