using InvestHarbor.Service.Extension;
using InvestHarbor.Service.Models;
using InvestHarbor.Service.Services.Seguranca;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestHarbor.Site.Controllers
{
    public class BaseController : Controller
    {
        public UsuarioLogado UsuarioLogado { get; set; }
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private ControleAcessoService _controleAcesso;
        private List<string> _permissoes;
        private bool permitido = false;

        public BaseController(IDataProtectionProvider dataProtectionProvider, List<string> permissoes = null)
        {
            _dataProtectionProvider = dataProtectionProvider;
            _controleAcesso = new ControleAcessoService();
            _permissoes = permissoes;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                base.OnActionExecuting(context);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var httpContext = Request.HttpContext;

            try
            {
                var usuario = httpContext.GetAuthCookieData<UsuarioLogado>(_dataProtectionProvider);
                UsuarioLogado = usuario;

                if (_permissoes != null)
                {
                    if (!_controleAcesso.Acessar(_permissoes, UsuarioLogado))
                    {
                        httpContext.Response.Redirect("/Home/Index");
                    }
                }
            }
            catch (Exception ex)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = NoContent();
                httpContext.Response.Redirect("");
            }
        }
    }
}
