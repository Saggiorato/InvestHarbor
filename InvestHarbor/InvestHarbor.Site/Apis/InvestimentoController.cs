using InvestHarbor.Data.Enum;
using InvestHarbor.Service.Models;
using InvestHarbor.Service.Models.Investimentos;
using InvestHarbor.Service.Services.Investimentos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestHarbor.Site.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly InvestimentoService _investimentoService;

        public InvestimentoController()
        {
            _investimentoService = new InvestimentoService();
        }

        [HttpGet]
        public async Task<RetornoViewModel> ObterInvestimentos(string filtro, TipoInvestimento? tipo)
        {
            var investimentos = await _investimentoService.ObterInvestimentos(filtro, tipo);

            return new RetornoViewModel { Dados = investimentos };
        }

        [HttpPost]
        public async Task<RetornoViewModel> AdicionarInvestimento([FromForm] InvestimentoViewModel dados)
        {
            var id = await _investimentoService.AdicionarInvestimento(dados);

            return new RetornoViewModel { Id = id };
        }

        [HttpPost("RemoverInvestimento")]
        public async Task<RetornoViewModel> RemoverInvestimento(Guid id)
        {
            var removido = await _investimentoService.RemoverInvestimento(id);

            return new RetornoViewModel();
        }
    }
}
