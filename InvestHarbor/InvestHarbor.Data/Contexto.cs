using InvestHarbor.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvestHarbor.Data
{
    public class Contexto : DbContext
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=InvestHarbor;Trusted_Connection=True;MultipleActiveResultSets=true";

        public Contexto() : base() { }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        // var contextBuilder = new DbContextOptionsBuilder<Contexto>().UseSqlServer("Server=tcp:108.166.181.95;Database=projeto-bots-corsan;User ID=sa;Password=@21Jvzlhzlcz;Connection Timeout=30;")
        //_contexto = new Contexto(contextBuilder.Options);

        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<CarteiraInvestimento> CarteirasInvestimentos { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteContaBancaria> ClienteContasBancarias { get; set; }
        public DbSet<ClienteInvestimento> ClientesInvestimentos { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Ordem> Ordens { get; set; }
        public DbSet<PagamentoRetirada> PagamentosRetiradas { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }
        public DbSet<Recebimento> Recebimentos { get; set; }
        public DbSet<RendimentoDividendo> RendimentosDividendos { get; set; }
        public DbSet<RendimentoDividendoCliente> RendimentosDividendosClientes { get; set; }
        public DbSet<Suporte> Suportes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPermissao> UsuariosPermissoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Carteira.Setup(builder);
            CarteiraInvestimento.Setup(builder);
            Chat.Setup(builder);
            Cliente.Setup(builder);
            ClienteContaBancaria.Setup(builder);
            ClienteInvestimento.Setup(builder);
            Log.Setup(builder);
            Movimentacao.Setup(builder);
            Ordem.Setup(builder);
            PagamentoRetirada.Setup(builder);
            Investimento.Setup(builder);
            Recebimento.Setup(builder);
            RendimentoDividendo.Setup(builder);
            RendimentoDividendoCliente.Setup(builder);
            Suporte.Setup(builder);
            Usuario.Setup(builder);
            UsuarioPermissao.Setup(builder);
        }

        public virtual void AtualizarTudo<T>(T model) where T : class
        {
            Entry(model).State = EntityState.Modified;
        }

        public virtual void AtualizarCampos<T>(T model, List<string> campos) where T : class
        {
            foreach (var campo in campos)
            {
                Entry(model).Property(campo).IsModified = true;
            }
        }

        public virtual void AtualizarUmCampo<T>(T model, string campo) where T : class
        {
            Entry(model).Property(campo).IsModified = true;
        }

        public virtual async Task AddAndSaveAsync<T>(T model) where T : class
        {
            await AddAsync(model);
            await SaveChangesAsync();
        }
    }
}
