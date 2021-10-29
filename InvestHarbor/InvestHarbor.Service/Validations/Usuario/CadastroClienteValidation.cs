using InvestHarbor.Service.Models.Acesso;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Service.Validations.Usuario
{
    public class CadastroClienteValidation
    {
        protected bool Validar(ClienteViewModel dados)
        {
            var valido = true;

            if (string.IsNullOrEmpty(dados.Nome))
                valido = false;

            if (string.IsNullOrEmpty(dados.Sobrenome))
                valido = false;

            if (string.IsNullOrEmpty(dados.Cpf))
                valido = false;

            if (dados.DataNascimento == DateTime.MinValue)
                valido = false;

            if (string.IsNullOrEmpty(dados.Cep))
                valido = false;

            return valido;
        }
    }
}
