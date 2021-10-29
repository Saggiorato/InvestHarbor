using InvestHarbor.Data;
using InvestHarbor.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestHarbor.Service.Services.Clientes
{
    public class ClienteService
    {
        private readonly Contexto _contexto;

        public ClienteService()
        {
            _contexto = new Contexto();
        }

        public async Task<RetornoViewModel> ObterClientes(string nome)
        {
            try
            {
                var clientes = _contexto.Clientes.Where(x => true);

                if (!string.IsNullOrEmpty(nome))
                    clientes = clientes.Where(x => x.Nome.ToLower().Contains(nome.ToLower()) || x.Sobrenome.ToLower().Contains(nome.ToLower()));

                return new RetornoViewModel { Dados = await clientes.ToListAsync() };
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }


        public async Task<RetornoViewModel> ObterClientesComSaldoDisponivel(string nome)
        {
            try
            {
                var clientes = _contexto.Clientes.Where(x => true);

                if (!string.IsNullOrEmpty(nome))
                    clientes = clientes.Where(x => x.Nome.ToLower().Contains(nome.ToLower()) || x.Sobrenome.ToLower().Contains(nome.ToLower()));

                var clientesSimples = clientes.Select(x => new
                {
                    Nome = x.Nome + " " + x.Sobrenome,
                    x.SaldoAtual
                });

                return new RetornoViewModel { Dados = await clientesSimples.ToListAsync() };
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }
    }
}
