using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class ClienteInvestimento
    {
        public Guid Id { get; set; }
        public Guid InvestimentoId { get; set; }
        public Guid OrdemId { get; set; }
        public Guid ClienteId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
