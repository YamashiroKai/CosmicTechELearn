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

namespace ELearn.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LecturerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult MatIndex()
        {
            IEnumerable<Material> objList = _db.Materials;
            return View(objList);
        }

        // GET: MaterialsController/Details/5
        public ActionResult MatDetails(int id)
        {
            return View();
        }

        // GET: MaterialsController/Create
        public ActionResult MatCreate()
        {
            return View();
        }

        // POST: MaterialsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MatCreate(Material obj)
        {
            if (ModelState.IsValid)
            {
                _db.Materials.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("MatIndex");
            }
            return View(obj);
        }

        // GET: MaterialsController/Edit/5
        public ActionResult MatEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Materials.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MatEdit(Material obj)
        {
            _db.Materials.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("MatIndex");
        }

        public ActionResult MatDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Materials.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MatDelete(Material obj)
        {
            _db.Materials.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("MatIndex");
        }
    }
}
