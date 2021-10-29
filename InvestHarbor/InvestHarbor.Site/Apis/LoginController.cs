using InvestHarbor.Service.Extension;
using InvestHarbor.Service.Models;
using InvestHarbor.Service.Services.Seguranca;
using InvestHarbor.Site.Service.Acesso;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestHarbor.Site.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private HttpContext _httpContext;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly LoginService _loginService;

        public LoginController(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
            _loginService = new LoginService();
        }

        [HttpPost]
        public async Task<RetornoViewModel> LoginUsuario([FromForm] LoginViewModel parametros)
        {
            var usuarioLogado = await _loginService.Logar(parametros.Cpf.ToLower(), parametros.Senha);

            //teste
            if(usuarioLogado == null)
            {
                usuarioLogado = new UsuarioLogado
                {
                    Nome = "Teste",
                };
            }

            if (usuarioLogado != null)
            {
                _httpContext = Request.HttpContext;
                _httpContext.SetAuthCookie(_dataProtectionProvider, false, usuarioLogado);
            }

            return new RetornoViewModel { Erro = usuarioLogado == null ? "Usuário não encontrado" : "" };
        }
    }
}
