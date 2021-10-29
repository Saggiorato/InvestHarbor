using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvestHarbor.Data.Enum
{
    public enum TipoInvestimento
    {
        [Display(Name = "Imobiliário")]
        Imobiliario = 0,
        [Display(Name = "Ações")]
        Acao = 1,
        [Display(Name = "Outros")]
        Outros = 2
    }
}
