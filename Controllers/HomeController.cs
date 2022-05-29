using ELearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ELearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }

        public IActionResult Lecturer()
        {
            return View();
        }

        public IActionResult HoD()
        {
            return View();
        }
        public IActionResult SubjectCoordinator()
        {
            return View();
        }

        public IActionResult Sponsor()
        {
            return View();
        }

        public IActionResult IndexNull()
        {
            return View();
        }

        public IActionResult IndexPassword()
        {
            return View();
        }

        public IActionResult IndexUn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string UserID, string Password)
        {
            if  ((UserID == "") | (UserID == null))
                return RedirectToAction("IndexNull", "Home");
            else if ((Password == "") | (Password == null))
                return RedirectToAction("IndexPassword", "Home");
            else if (UserID == "220759375")
                return RedirectToAction("Dashboard", "Lecturer");
            else
                return RedirectToAction("IndexUn", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
