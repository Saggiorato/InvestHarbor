using InvestHarbor.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class Ordem
    {
        public Guid Id { get; set; }
        public Guid CarteiraId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid MovimentacaoId { get; set; }
        public DateTime Data { get; set; }
        public TipoOrdem Tipo { get; set; }
        public bool Executada { get; set; }
    }
}
