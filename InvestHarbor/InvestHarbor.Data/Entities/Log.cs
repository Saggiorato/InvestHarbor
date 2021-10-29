using InvestHarbor.Data.Enum;
using System;

namespace InvestHarbor.Data.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public Guid UsuarioId { get; set; }
        public TipoAcaoUsuario Acao { get; set; }
        public string Tela { get; set; }
        public string Observacao { get; set; }
    }
}
