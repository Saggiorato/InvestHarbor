using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Service.Models
{
    public class UsuarioLogado
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }
        public List<string> Permissoes { get; set; }
    }
}
