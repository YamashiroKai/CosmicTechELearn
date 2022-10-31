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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ELearn.Controllers
{
    public class SponsorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SponsorController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "SuperAdmin, Sponsor")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Sponsor")]
        public ActionResult Index()
        {
            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Sponsor> objList = _db.Sponsors;

            if (!String.IsNullOrEmpty(ViewBag.own_id))
                objList = objList.Where(s => s.Id.Contains(ViewBag.own_id));

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, Sponsor")]
        public ActionResult Register()
        {
            var obj = new Sponsor();
            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Sponsor obj)
        {
            _db.Sponsors.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "SuperAdmin, Sponsor")]
        public ActionResult EditDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Sponsors.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails(Sponsor obj)
        {
            _db.Sponsors.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }


    }
}
