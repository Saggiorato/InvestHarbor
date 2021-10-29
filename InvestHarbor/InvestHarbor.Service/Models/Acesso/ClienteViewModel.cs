using InvestHarbor.Service.Validations.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestHarbor.Service.Models.Acesso
{
    public class ClienteViewModel : CadastroClienteValidation
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Token { get; set; }
        public Guid UsuarioId { get; set; }

        public bool Valido()
        {
            return Validar(this);
        }
    }
}
