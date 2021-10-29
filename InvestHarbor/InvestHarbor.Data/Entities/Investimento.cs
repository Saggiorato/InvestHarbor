using InvestHarbor.Data.Enum;
using InvestHarbor.Data.Formatacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class Investimento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoInvestimento Tipo { get; set; }
        public decimal Cotacao { get; set; }
        public decimal UltimaCotacao { get; set; }
        [NotMapped]
        public string DescricaoTipo
        {
            get
            {
                return DisplayEnum.GetDisplayNameEnum(Tipo);
            }
        }
    }
}
