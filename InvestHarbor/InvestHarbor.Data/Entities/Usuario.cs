using InvestHarbor.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Data.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public Guid? ClienteId { get; set; }
        public string Email { get; set; }
        public bool EmailVerificado { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Token { get; set; }
        public DateTime UltimoLogin { get; set; }
        public string Ip { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoUsuario Tipo { get; set; }
    }
}
