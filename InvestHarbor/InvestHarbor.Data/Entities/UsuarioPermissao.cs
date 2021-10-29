using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class UsuarioPermissao
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid PermissaoId { get; set; }
    }
}
