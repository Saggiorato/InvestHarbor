using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class Suporte
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public string Mensagem { get; set; }
        public bool Atendido { get; set; }
        public bool Finalizado { get; set; }
        public string Observacao { get; set; }
    }
}
