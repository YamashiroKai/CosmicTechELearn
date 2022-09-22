using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using ELearn.Data;
using ELearn.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELearn.Controllers
{
    public class SubjectCoordinatorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SubjectCoordinatorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
