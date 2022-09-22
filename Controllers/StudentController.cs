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
    public class StudentController : Controller
    {   
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        /// Material

        public ActionResult MatIndex(string sortOrder, string searchString)
        {
            ViewBag.SortWeek = String.IsNullOrEmpty(sortOrder) ? "week_desc" : "";
            ViewBag.SortMod = sortOrder == "mod_asc" ? "mod_desc" : "mod_asc";
            ViewBag.SortApproved = sortOrder == "approved_asc" ? "approved_desc" : "approved_asc";

            IEnumerable<Material> objList = _db.Materials;

            if (!String.IsNullOrEmpty(searchString))
                objList = objList.Where(s => s.Description.Contains(searchString));

            switch (sortOrder)
            {
                case "week_desc":
                    objList = objList.OrderByDescending(s => s.Week);
                    break;
                case "mod_asc":
                    objList = objList.OrderBy(s => s.ModID);
                    break;
                case "mod_desc":
                    objList = objList.OrderByDescending(s => s.ModID);
                    break;
                case "approved_asc":
                    objList = objList.OrderBy(s => s.Active);
                    break;
                case "approved_desc":
                    objList = objList.OrderByDescending(s => s.Active);
                    break;
                default:
                    objList = objList.OrderBy(s => s.Week);
                    break;
            }
            return View(objList);
        }

        public ActionResult MatDetails(int id)
        {
            return View();
        }

        public ActionResult MatCreate()
        {
            var obj = new Material();
            obj.Modules = _db.Modules
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.ModID.ToString(),
                                      Text = a.Name
                                  })
                                  .ToList();

            return View(obj);
        }

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
            obj.Modules = _db.Modules
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.ModID.ToString(),
                                      Text = a.Name
                                  })
                                  .ToList();

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
            obj.Modules = _db.Modules
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.ModID.ToString(),
                                      Text = a.Name
                                  })
                                  .ToList();

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

        /// Submissions

        public ActionResult SubIndex(string sortOrder, string searchString)
        {
            ViewBag.SortWeek = String.IsNullOrEmpty(sortOrder) ? "week_desc" : "";
            ViewBag.SortMod = sortOrder == "mod_asc" ? "mod_desc" : "mod_asc";
            ViewBag.SortDue = sortOrder == "due_asc" ? "due_desc" : "due_asc";
            ViewBag.SortStart = sortOrder == "start_asc" ? "start_desc" : "start_asc";

            IEnumerable<Submission> objList = _db.Submissions;

            if (!String.IsNullOrEmpty(searchString))
                objList = objList.Where(s => s.Description.Contains(searchString));

            switch (sortOrder)
            {
                case "week_desc":
                    objList = objList.OrderByDescending(s => s.Week);
                    break;
                case "mod_asc":
                    objList = objList.OrderBy(s => s.ModID);
                    break;
                case "mod_desc":
                    objList = objList.OrderByDescending(s => s.ModID);
                    break;
                case "due_asc":
                    objList = objList.OrderBy(s => s.DueDate);
                    break;
                case "due_desc":
                    objList = objList.OrderByDescending(s => s.DueDate);
                    break;
                case "start_asc":
                    objList = objList.OrderBy(s => s.StartDate);
                    break;
                case "start_desc":
                    objList = objList.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    objList = objList.OrderBy(s => s.Week);
                    break;
            }

            return View(objList);
        }

        public ActionResult SubDetails(int id)
        {
            return View();
        }

        public ActionResult SubCreate()
        {
            var obj = new Submission();
            obj.Modules = _db.Modules
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.ModID.ToString(),
                                      Text = a.Name
                                  })
                                  .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubCreate(Submission obj)
        {
            if (ModelState.IsValid)
            {
                _db.Submissions.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("SubIndex");
            }
            return View(obj);
        }

        public ActionResult SubEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Submissions.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.Modules = _db.Modules
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.ModID.ToString(),
                                      Text = a.Name
                                  })
                                  .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubEdit(Submission obj)
        {
            _db.Submissions.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("SubIndex");
        }

        public ActionResult SubDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Submissions.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubDelete(Submission obj)
        {
            _db.Submissions.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("SubIndex");
        }

        public ActionResult SubStuIndex(int? id)
        {
            ViewBag.ID = id;

            IEnumerable<Submission_Student> objList = _db.Submissions_Students;
            return View(objList);
        }

        public ActionResult SubStuGrade(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Submissions_Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubStuGrade(Submission_Student obj)
        {
            _db.Submissions_Students.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("SubIndex");
        }

    }
}
