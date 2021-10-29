using InvestHarbor.Service.Models.Investimentos;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Service.Validations.Investimentos
{
    public class InvestimentoValidation
    {
        protected bool Validar(InvestimentoViewModel dados)
        {
            var valido = true;

            if (string.IsNullOrEmpty(dados.Nome))
                valido = false;

            if (dados.Tipo == null)
                valido = false;

            return valido;
        }
    }
}
