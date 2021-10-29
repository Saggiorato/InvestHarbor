using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class Carteira
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativa { get; set; }
        public bool Bloqueada { get; set; }
        public int LimiteUtilizacao { get; set; }
        public decimal Valor { get; set; }
    }
}
