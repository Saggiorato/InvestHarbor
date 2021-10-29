using InvestHarbor.Data;
using InvestHarbor.Data.Models;
using InvestHarbor.Service.Models;
using InvestHarbor.Service.Models.Carteira;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestHarbor.Service.Services.Carteiras
{
    public class CarteiraService
    {
        private readonly Contexto _contexto;

        public CarteiraService()
        {
            _contexto = new Contexto();
        }

        public async Task<List<Carteira>> ObterCarteiras(string carteira, string investimento)
        {
            try
            {
                var carteiras = _contexto.Carteiras.Where(x => true);

                if (!string.IsNullOrEmpty(carteira))
                    carteiras = carteiras.Where(x => x.Nome.ToLower().Contains(carteira.Trim().ToLower()) || x.Descricao.ToLower().Contains(carteira.Trim().ToLower()));

                if (!string.IsNullOrEmpty(investimento))
                    carteiras = carteiras.Where(x => x.InvestimentosCarteira.Any(i => i.Investimento.Nome.Trim().ToLower().Contains(investimento.Trim().ToLower())));

                return await carteiras.ToListAsync();
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }

        public async Task<RetornoViewModel> AdicionarCarteira(CarteiraViewModel model)
        {
            try
            {
                if (!model.Valido())
                    return new RetornoViewModel { Erro = "Confira os dados informados" };

                var carteira = new Carteira
                {
                    Id = model.Id ?? Guid.Empty,
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    InvestimentosCarteira = new List<CarteiraInvestimento>()
                };

                if (model.CarteiraInvestimentos != null)
                {
                    foreach (var item in model.CarteiraInvestimentos)
                    {
                        carteira.InvestimentosCarteira.Add(new CarteiraInvestimento
                        {
                            Id = item.Id ?? Guid.Empty,
                            Carteira = carteira,
                            CarteiraId = carteira.Id,
                            InvestimentoId = item.InvestimentoId,
                            PorcentagemCarteira = item.PorcentagemCarteira
                        });
                    }
                }

                if (carteira.Id != Guid.Empty)
                    _contexto.Update(carteira);
                else
                    await _contexto.AddAsync(carteira);

                await _contexto.SaveChangesAsync();

                return new RetornoViewModel { Id = carteira.Id };
            }
            catch (Exception ex)
            {
                //log
                return new RetornoViewModel { Erro = "Não foi possivel inserir" };
            }
        }

        public async Task<bool> RemoverCarteira(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return false;

                _contexto.Remove(new Carteira { Id = id });
                await _contexto.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log
                return false;
            }
        }

        public async Task<bool> RemoverCarteiraInvestimento(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return false;

                _contexto.Remove(new CarteiraInvestimento { Id = id });
                await _contexto.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log
                return false;
            }
        }

        public async Task<RetornoViewModel> ObterCarteiraInvestimentos(Guid carteiraId)
        {
            try
            {
                var carteiraInvestimentos = await _contexto.CarteirasInvestimentos.Where(x => x.CarteiraId == carteiraId).Include(x => x.Investimento)
                    .Select(x => new
                    {
                        x.Id,
                        x.InvestimentoId,
                        x.CarteiraId,
                        x.PorcentagemCarteira,
                        Nome = x.Investimento.Nome
                    }).ToListAsync();

                return new RetornoViewModel { Dados = carteiraInvestimentos };
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }
    }
}
