using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Models
{
    public class Chat : Entities.Chat
    {
        public virtual Usuario Usuario { get; set; }
        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Chat>().ToTable("Chats");
            builder.Entity<Chat>().HasKey(x => x.Id);
            builder.Entity<Chat>().HasIndex(x => x.Id);
            builder.Entity<Chat>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Chat>()
                    .Property(x => x.Mensagem)
                    .HasColumnType("varchar(100)");

            builder.Entity<Chat>()
                   .HasOne(x => x.Usuario)
                   .WithMany(x => x.Chats)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.UsuarioId);
        }
    }
}
