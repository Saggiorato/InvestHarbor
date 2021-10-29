using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestHarbor.Service.Models
{
    public class RetornoViewModel
    {
        public bool Sucesso
        {
            get
            {
                return string.IsNullOrEmpty(Erro) && (Erros == null || Erros.Count() <= 0);
            }
        }
        public string Erro { get; set; }
        public List<string> Erros { get; set; }
        public object Dados { get; set; }
        public Guid? Id { get; set; }
    }
}
