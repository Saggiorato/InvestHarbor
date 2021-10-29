using InvestHarbor.Service.Validations.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestHarbor.Service.Models.Acesso
{
    public class CadastroViewModel : CadastroUsuarioValidation
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string Confirmacao { get; set; }

        public bool Valido()
        {
            return Validar(this);
        }
    }
}
