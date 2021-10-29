using InvestHarbor.Service.Models.Acesso;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Service.Validations.Usuario
{
    public class CadastroUsuarioValidation
    {
        protected bool Validar(CadastroViewModel dados)
        {
            var valido = true;

            if (string.IsNullOrEmpty(dados.Email))
                valido = false;

            if (string.IsNullOrEmpty(dados.Telefone))
                valido = false;

            if (string.IsNullOrEmpty(dados.Senha))
                valido = false;

            if (dados.Senha != dados.Confirmacao)
                valido = false;

            return valido;
        }
    }
}
