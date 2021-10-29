using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class ClienteContaBancaria
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string Entidade { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public bool Principal { get; set; }
    }
}
