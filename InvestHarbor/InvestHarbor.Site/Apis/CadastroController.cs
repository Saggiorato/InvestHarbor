using InvestHarbor.Service.Models;
using InvestHarbor.Service.Models.Acesso;
using InvestHarbor.Service.Services.Seguranca;
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
    public class CadastroController : ControllerBase
    {
        private readonly CadastroService _cadastroService;

        public CadastroController()
        {
            _cadastroService = new CadastroService();
        }

        [HttpPost]
        public async Task<RetornoViewModel> Cadastro([FromForm] CadastroViewModel parametros)
        {
            var cadastro = await _cadastroService.CadastrarUsuario(parametros);

            return new RetornoViewModel();
        }

        [HttpPost("Cliente")]
        public async Task<RetornoViewModel> Cliente([FromForm] ClienteViewModel parametros)
        {
            var cadastro = await _cadastroService.CadastrarCliente(parametros);

            return new RetornoViewModel();
        }
    }
}
