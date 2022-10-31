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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ELearn.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LecturerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public int[] GetModules()
        {
            IEnumerable<Lecturer_Module> lec_modules = _db.Lecturers_Modules;
            IEnumerable<Lecturer> lecturers = _db.Lecturers;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            lecturers = lecturers.Where(s => s.Id.Contains(userId));
            int lecturer_id = lecturers.First().LecturerID;
            lec_modules = lec_modules.Where(s => s.LecturerID.Equals(lecturer_id));

            int[] module_codes = new int[20];
            foreach (Lecturer_Module lec in lec_modules)
            {
                module_codes.Append(lec.ModID);
            }

            return module_codes;
        }
        
        /// User

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public ActionResult Index()
        {
            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Lecturer> objList = _db.Lecturers;

            if (!String.IsNullOrEmpty(ViewBag.own_id))
                objList = objList.Where(s => s.Id.Contains(ViewBag.own_id));

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public ActionResult Register()
        {
            var obj = new Lecturer();
            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            obj.Offices = _db.Offices
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.OfficeID.ToString(),
                                      Text = a.Location + a.BuildingName
                                  })
                                  .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Lecturer obj)
        {
            _db.Lecturers.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public ActionResult EditDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Lecturers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            obj.Offices = _db.Offices
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.OfficeID.ToString(),
                                      Text = a.Location + a.BuildingName
                                  })
                                  .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails(Lecturer obj)
        {
            _db.Lecturers.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        /// Material

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public ActionResult MatIndex(string sortOrder, string SearchString, string mod_id)
        {
            ViewBag.SortWeek = String.IsNullOrEmpty(sortOrder) ? "week_desc" : "";
            ViewBag.SortMod = sortOrder == "mod_asc" ? "mod_desc" : "mod_asc";
            ViewBag.SortApproved = sortOrder == "approved_asc" ? "approved_desc" : "approved_asc";
            ViewBag.ModID = mod_id;
            
            if (!String.IsNullOrEmpty(SearchString))
            {
                ViewBag.Search = int.Parse(SearchString);
            }
            else ViewBag.Search = 0;
            
            IEnumerable<Material> objList = _db.Materials;

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

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public ActionResult MatDetails(int id)
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Lecturer")]
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

        [Authorize(Roles = "SuperAdmin, Lecturer")]
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

        [Authorize(Roles = "SuperAdmin, Lecturer")]
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

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public ActionResult SubIndex(string sortOrder, string SearchString)
        {
            ViewBag.SortWeek = String.IsNullOrEmpty(sortOrder) ? "week_desc" : "";
            ViewBag.SortMod = sortOrder == "mod_asc" ? "mod_desc" : "mod_asc";
            ViewBag.SortDue = sortOrder == "due_asc" ? "due_desc" : "due_asc";
            ViewBag.SortStart = sortOrder == "start_asc" ? "start_desc" : "start_asc";

            if (!String.IsNullOrEmpty(SearchString))
            {
                ViewBag.Search = int.Parse(SearchString);
            }
            else ViewBag.Search = 0;

            IEnumerable<Submission> objList = _db.Submissions;

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

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public ActionResult SubDetails(int id)
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Lecturer")]
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

        [Authorize(Roles = "SuperAdmin, Lecturer")]
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

        [Authorize(Roles = "SuperAdmin, Lecturer")]
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

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public ActionResult SubStuIndex(int? id, int total)
        {
            ViewBag.ID = id;
            ViewBag.Total = total;

            IEnumerable<Submission_Student> objList = _db.Submissions_Students;

            int counter = 0;
            double totalMarks = 0;
            double lowest = 100;
            double highest = 0;
            double averageMark;
            double averagePercentage;

            foreach(var item in objList)
            {
                if(item.SubID == ViewBag.ID)
                {
                    counter++; 
                    totalMarks += item.Grade;
                }
                if(item.Grade > highest) highest = item.Grade;
                if(item.Grade < lowest) lowest = item.Grade;
            }
            averageMark = Math.Round(totalMarks / counter);
            averagePercentage = Math.Round(((totalMarks / counter) / total) * 100);

            ViewBag.AverageMark = averageMark;
            ViewBag.AveragePercentage = averagePercentage;
            ViewBag.Lowest = lowest;
            ViewBag.Highest = highest;
            ViewBag.Entries = counter;

            return View(objList);
        }

        public ActionResult SubStuIndexReport(int? id, int total)
        {
            ViewBag.ID = id;
            ViewBag.Total = total;

            IEnumerable<Submission_Student> objList = _db.Submissions_Students;

            int counter = 0;
            double totalMarks = 0;
            double lowest = 100;
            double highest = 0;
            double averageMark;
            double averagePercentage;

            foreach (var item in objList)
            {
                if (item.SubID == ViewBag.ID)
                {
                    counter++;
                    totalMarks += item.Grade;
                }
                if (item.Grade > highest) highest = item.Grade;
                if (item.Grade < lowest) lowest = item.Grade;
            }
            averageMark = Math.Round(totalMarks / counter);
            averagePercentage = Math.Round(((totalMarks / counter) / total) * 100);

            ViewBag.AverageMark = averageMark;
            ViewBag.AveragePercentage = averagePercentage;
            ViewBag.Lowest = lowest;
            ViewBag.Highest = highest;
            ViewBag.Entries = counter;

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, Lecturer")]
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
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Authorize(Roles = "SuperAdmin, Lecturer")]
        public ActionResult SubStuDelete(int? id)
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
        public ActionResult SubStuDelete(Submission_Student obj)
        {
            _db.Submissions_Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("SubIndex");
        }
    }
}
