using InvestHarbor.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvestHarbor.Service.Services.Seguranca
{
    public class ControleAcessoService
    {
        public bool Acessar(List<string> permissoesNecessarias, UsuarioLogado usuarioLogado)
        {
            //todo: retirar
            if (usuarioLogado.Permissoes != null)
            {
                var temPermissao = permissoesNecessarias.FirstOrDefault(x => usuarioLogado.Permissoes.Any(u => u == x));

                if (!string.IsNullOrEmpty(temPermissao))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
