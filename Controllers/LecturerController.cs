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
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LecturerController(ApplicationDbContext db)
        {
            _db = db;
        }

        private readonly ILogger<HomeController> _logger;

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Submission()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                                      Text = a.ModCode
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
                                      Text = a.ModCode
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
                                      Text = a.ModCode
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

        public ActionResult SubIndex()
        {
            IEnumerable<Submission> objList = _db.Submissions;
            return View(objList);
        }

        public ActionResult SubDetails(int id)
        {
            return View();
        }

        public ActionResult SubCreate()
        {
            return View();
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
            List<Module> ModuleList = new List<Module>();
            string sqlQuery = "execute sp_GetBookAuthors @bookname = 'Book A'";
            //var result = _db.GetBookAuthors(sqlQuery);

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
            
            //if (id == null || id == 0)
            //{
            //    return NoSubmissions();
            //}
            // var obj = _db.Submissions_Students.Find(id);
            //if (obj == null)
            //{
            //    return NoSubmissions();
            //}
            IEnumerable<Submission_Student> objList = _db.Submissions_Students;
            return View(objList);
        }

        public ActionResult SubStuGrade(int id)
        {
            return View();
        }

        public ActionResult NoSubmissions()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }
    }
}
