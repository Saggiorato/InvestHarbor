using InvestHarbor.Service.Models.Carteira;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Service.Validations.Carteiras
{
    public class CarteiraValidation
    {
        protected bool Validar(CarteiraViewModel dados)
        {
            var valido = true;

            if (string.IsNullOrEmpty(dados.Nome))
                valido = false;

            return valido;
        }
    }
}
