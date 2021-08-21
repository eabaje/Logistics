using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Logistics.Service.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Service.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoadBoard()
        {
            return View();
        }
        public IActionResult Broker()
        {
            return View();
        }
        public IActionResult Carrier()
        {
            return View();
        }
        public IActionResult Shipper()
        {
            return View();
        }
        public IActionResult FindLoad()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult HowItWorks()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Service()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
