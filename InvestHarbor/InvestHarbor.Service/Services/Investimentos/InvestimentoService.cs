using InvestHarbor.Data;
using InvestHarbor.Data.Enum;
using InvestHarbor.Data.Models;
using InvestHarbor.Service.Models;
using InvestHarbor.Service.Models.Investimentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestHarbor.Service.Services.Investimentos
{
    public class InvestimentoService
    {
        private readonly Contexto _contexto;

        public InvestimentoService()
        {
            _contexto = new Contexto();
        }

        public async Task<List<Investimento>> ObterInvestimentos(string filtro, TipoInvestimento? tipo)
        {
            try
            {
                var investimentos = _contexto.Investimentos.Where(x => true);

                if (!string.IsNullOrEmpty(filtro))
                    investimentos = investimentos.Where(x => x.Nome.ToLower().Contains(filtro.Trim().ToLower()) || x.Descricao.ToLower().Contains(filtro.Trim().ToLower()));

                if (tipo != null)
                    investimentos = investimentos.Where(x => x.Tipo == tipo);

                return await investimentos.ToListAsync();
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }

        public async Task<Guid> AdicionarInvestimento(InvestimentoViewModel model)
        {
            try
            {
                if (!model.Valido())
                    return Guid.Empty;

                var investimento = new Investimento
                {
                    Id = model.Id != null ? (Guid)model.Id : Guid.Empty,
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    Tipo = (TipoInvestimento)model.Tipo
                };

                if (investimento.Id != Guid.Empty)
                    _contexto.Update(investimento);
                else
                    await _contexto.AddAsync(investimento);

                await _contexto.SaveChangesAsync();

                return investimento.Id;
            }
            catch (Exception ex)
            {
                //log
                return Guid.Empty;
            }
        }

        public async Task<bool> RemoverInvestimento(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return false;

                _contexto.Remove(new Investimento { Id = id });
                await _contexto.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log
                return false;
            }
        }
    }
}
