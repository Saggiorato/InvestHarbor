using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class RendimentoDividendoCliente
    {
        public Guid Id { get; set; }
        public Guid RendimentoId { get; set; }
        public Guid ClienteId { get; set; }
        public decimal Valor { get; set; }
        public bool Pago { get; set; }
    }
}
