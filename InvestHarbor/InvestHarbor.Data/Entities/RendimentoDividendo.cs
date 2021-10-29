using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class RendimentoDividendo
    {
        public Guid Id { get; set; }
        public Guid InvestimentoId { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
