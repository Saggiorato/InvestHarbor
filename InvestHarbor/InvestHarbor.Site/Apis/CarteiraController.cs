using InvestHarbor.Service.Models;
using InvestHarbor.Service.Models.Carteira;
using InvestHarbor.Service.Services.Carteiras;
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
    public class CarteiraController : ControllerBase
    {
        private readonly CarteiraService _carteiraService;

        public CarteiraController()
        {
            _carteiraService = new CarteiraService();
        }

        [HttpGet]
        public async Task<RetornoViewModel> ObterCarteiras(string carteira, string investimento)
        {
            var carteiras = await _carteiraService.ObterCarteiras(carteira, investimento);

            return new RetornoViewModel { Dados = carteiras };
        }

        [HttpPost]
        public async Task<RetornoViewModel> AdicionarCarteira([FromForm] CarteiraViewModel dados)
        {
            var retorno = await _carteiraService.AdicionarCarteira(dados);

            return retorno;
        }

        [HttpPost("Remover")]
        public async Task<RetornoViewModel> Remover(Guid id)
        {
            var removido = await _carteiraService.RemoverCarteira(id);

            return new RetornoViewModel();
        }

        [HttpPost("RemoverCarteiraInvestimento")]
        public async Task<RetornoViewModel> RemoverCarteiraInvestimento(Guid id)
        {
            var removido = await _carteiraService.RemoverCarteiraInvestimento(id);

            return new RetornoViewModel();
        }

        [HttpGet("ObterCarteiraInvestimentos")]
        public async Task<RetornoViewModel> ObterCarteiraInvestimentos(Guid id)
        {
            var retorno = await _carteiraService.ObterCarteiraInvestimentos(id);

            return retorno;
        }
    }
}
