using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class Chat
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public Guid UsuarioId { get; set; }
        public string Mensagem { get; set; }
        public bool Admin { get; set; }
    }
}
