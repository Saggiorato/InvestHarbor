using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Service.Models.Carteira
{
    public class CarteiraInvestimentoModel
    {
        public Guid? Id { get; set; }
        public Guid CarteiraId { get; set; }
        public Guid InvestimentoId { get; set; }
        public bool Ativo { get; set; }
        public bool Bloqueado { get; set; }
        public decimal PorcentagemCarteira { get; set; }
        public decimal LimitePreco { get; set; }
    }
}
