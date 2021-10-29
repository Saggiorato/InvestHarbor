using InvestHarbor.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public Guid InvestimentoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public bool Executada { get; set; }
    }
}
