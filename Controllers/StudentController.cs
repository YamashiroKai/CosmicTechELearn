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
    public class StudentController : Controller
    {   
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public IActionResult Dashboard()
        {
            return View();
        }

        /// Register

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult Index()
        {
            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Student> objList = _db.Students;

            if (!String.IsNullOrEmpty(ViewBag.own_id))
                objList = objList.Where(s => s.Id.Contains(ViewBag.own_id));

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult Register()
        {
            var obj = new Student();
            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            obj.Accomodations = _db.Accomodations
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.AccomID.ToString(),
                                      Text = a.Address + a.BuildingName
                                  })
                                  .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Student obj)
        {
            _db.Students.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult EditDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            obj.Accomodations = _db.Accomodations
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.AccomID.ToString(),
                                      Text = a.Address + a.BuildingName
                                  })
                                  .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails(Student obj)
        {
            _db.Students.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        /// Material

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult MatIndex(string sortOrder, string searchString)
        {
            ViewBag.SortWeek = String.IsNullOrEmpty(sortOrder) ? "week_desc" : "";
            ViewBag.SortMod = sortOrder == "mod_asc" ? "mod_desc" : "mod_asc";
            ViewBag.SortApproved = sortOrder == "approved_asc" ? "approved_desc" : "approved_asc";
            ViewData["CurrentFilter"] = searchString;

            IEnumerable<Material> objList = _db.Materials;

            if (!String.IsNullOrEmpty(searchString))
                objList = objList.Where(s => s.ModID.Equals(searchString));

            objList = objList.Where(s => s.Active.Equals(true));

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

        /// Submissions

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult SubIndex(string sortOrder, string searchString)
        {
            ViewBag.SortWeek = String.IsNullOrEmpty(sortOrder) ? "week_desc" : "";
            ViewBag.SortMod = sortOrder == "mod_asc" ? "mod_desc" : "mod_asc";
            ViewBag.SortDue = sortOrder == "due_asc" ? "due_desc" : "due_asc";
            ViewBag.SortStart = sortOrder == "start_asc" ? "start_desc" : "start_asc";
            ViewData["CurrentFilter"] = searchString;

            IEnumerable<Submission> objList = _db.Submissions;

            if (!String.IsNullOrEmpty(searchString))
                objList = objList.Where(s => s.ModID.Equals(searchString));

            objList = objList.Where(s => s.Active.Equals(true));

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

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult SubDetails(int id)
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult SubStuIndex(int? id)
        {
            ViewBag.ID = id;

            IEnumerable<Submission_Student> objList = _db.Submissions_Students;
            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult SubStuCreate(int? id)
        {
            var obj = new Submission_Student();
            ViewBag.sub_id = id;
            ViewBag.stud_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id == null || id == 0)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubStuCreate(Submission_Student obj)
        {
                _db.Submissions_Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("SubIndex");
        }

        // Courses

        //ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public ActionResult CourseIndex()
        {
            IEnumerable<Course> objList = _db.Courses;

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult CourseApply(int? id)
        {
            var obj = new Student_Course();
            ViewBag.id = id;

            if (id == null || id == 0)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseApply(Student_Course obj)
        {
            _db.Students_Courses.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        // Modules

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult ModuleIndex(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            IEnumerable<Module_Course> objList = _db.Modules_Courses;

            if (!String.IsNullOrEmpty(searchString))
                objList = objList.Where(s => s.CourseID.Equals(searchString));

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult ModuleView(int? indexid, int modid)
        {
            var obj = _db.Modules.Find(modid);
            ViewBag.modid = modid;

            return View(obj);
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult ModuleRegister(int? modid)
        {
            var obj = new Student_Module();
            ViewBag.modid = modid;

            if (modid == null || modid == 0)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModuleRegister(Student_Module obj)
        {
            //if (ModelState.IsValid){
                _db.Students_Modules.Add(obj);
                _db.SaveChanges();
            //}
            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult RegistedModuleIndex(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            IEnumerable<Student_Module> objList = _db.Students_Modules;

            if (!String.IsNullOrEmpty(searchString))
                objList = objList.Where(s => s.StudentID.Equals(searchString));

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, Student")]
        public ActionResult ModuleDetails(int? id)
        {
            var obj = _db.Students_Modules.Find(id);

            return View(obj);
        }
    }
}
