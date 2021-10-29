using InvestHarbor.Service.Validations.Carteiras;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Service.Models.Carteira
{
    public class CarteiraViewModel : CarteiraValidation
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativa { get; set; }
        public bool Bloqueada { get; set; }
        public int LimiteUtilizacao { get; set; }
        public decimal Valor { get; set; }
        public List<CarteiraInvestimentoModel> CarteiraInvestimentos { get; set; }

        public bool Valido()
        {
            return Validar(this);
        }
    }
}
