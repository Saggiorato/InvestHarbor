using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestHarbor.Site.Controllers
{
    public class CarteiraController : BaseController
    {
        private static readonly List<string> permissoes = new List<string> { "Admin" };

        public CarteiraController(IDataProtectionProvider dataProtectionProvider) : base(dataProtectionProvider, permissoes)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
