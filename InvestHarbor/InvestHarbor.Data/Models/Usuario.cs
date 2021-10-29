using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Usuario : Entities.Usuario
    {
        public virtual Cliente Cliente { get; set; }
        public virtual List<Chat> Chats { get; set; }
        public virtual List<Log> Logs { get; set; }
        public virtual List<Suporte> Suportes { get; set; }
        public virtual List<UsuarioPermissao> Permissoes { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<Usuario>().HasKey(x => x.Id);
            builder.Entity<Usuario>().HasIndex(x => x.Id);
            builder.Entity<Usuario>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Usuario>()
                   .Property(x => x.Email)
                   .HasColumnType("varchar(50)");

            builder.Entity<Usuario>()
                   .Property(x => x.Senha)
                   .HasColumnType("varchar(100)");

            builder.Entity<Usuario>()
                   .Property(x => x.Telefone)
                   .HasColumnType("varchar(15)");

            builder.Entity<Usuario>()
                   .Property(x => x.Token)
                   .HasColumnType("varchar(100)");

            builder.Entity<Usuario>()
                   .Property(x => x.Ip)
                   .HasColumnType("varchar(50)");

            builder.Entity<Usuario>()
                   .HasOne(x => x.Cliente)
                   .WithOne(x => x.Usuario)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey<Usuario>(x => x.ClienteId);
        }
    }
}
