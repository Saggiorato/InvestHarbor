using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class PagamentoRetirada
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid ClienteContaBancariaId { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public bool Efetuado { get; set; }
    }
}
