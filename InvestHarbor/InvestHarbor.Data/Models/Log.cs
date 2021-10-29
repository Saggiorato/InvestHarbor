using Microsoft.EntityFrameworkCore;

namespace InvestHarbor.Data.Models
{
    public class Log : Entities.Log
    {
        public virtual Usuario Usuario { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Log>().ToTable("Logs");
            builder.Entity<Log>().HasKey(x => x.Id);
            builder.Entity<Log>().HasIndex(x => x.Id);
            builder.Entity<Log>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Log>()
                   .Property(x => x.Tela)
                   .HasColumnType("varchar(100)");

            builder.Entity<Log>()
                   .Property(x => x.Observacao)
                   .HasColumnType("varchar(400)");

            builder.Entity<Log>()
                   .HasOne(x => x.Usuario)
                   .WithMany(x => x.Logs)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(x => x.UsuarioId);
        }
    }
}
