using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Service.API.Controllers
{
    [Route("SecureArea")]
    public class SecureAreaController : Controller
    {
        [Route("{view=Index}")]
        public IActionResult Index(string view)
        {
            ViewData["Title"] = "";

            return View(view);
        }
    }
}