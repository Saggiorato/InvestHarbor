using InvestHarbor.Data.Enum;
using InvestHarbor.Service.Validations.Investimentos;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Service.Models.Investimentos
{
    public class InvestimentoViewModel : InvestimentoValidation
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoInvestimento? Tipo { get; set; }
        public decimal Cotacao { get; set; }
        public decimal UltimaCotacao { get; set; }

        public bool Valido()
        {
            return Validar(this);
        }
    }
}
