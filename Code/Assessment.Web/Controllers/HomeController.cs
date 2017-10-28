using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assessment.Web.Models;

namespace Assessment.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Clients");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Built by developer Brady Kelly, who has close on 20 years experience.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "My mail address is brady@bradykelly.net. I'm plain 'bradykelly' on twitter.";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
