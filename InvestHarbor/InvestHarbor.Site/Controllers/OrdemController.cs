using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestHarbor.Site.Controllers
{
    public class OrdemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
