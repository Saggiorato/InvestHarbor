using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class Recebimento
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public Guid ClienteId { get; set; }
        public decimal Valor { get; set; }
        public bool Conciliado { get; set; }
        public string Observacao { get; set; }
    }
}
