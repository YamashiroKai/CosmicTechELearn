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
    public class HODController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HODController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult Index()
        {
            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<HeadOfDepartment> objList = _db.HeadOfDepartments;

            if (!String.IsNullOrEmpty(ViewBag.own_id))
                objList = objList.Where(s => s.Id.Contains(ViewBag.own_id));

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult Register()
        {
            var obj = new HeadOfDepartment();
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
        public ActionResult Register(HeadOfDepartment obj)
        {
            _db.HeadOfDepartments.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
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
        public ActionResult EditDetails(HeadOfDepartment obj)
        {
            _db.HeadOfDepartments.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        //courses

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult CourseIndex()
        {
            IEnumerable<Course> objList = _db.Courses;

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult CourseCreate()
        {
            var obj = new Course();
            obj.SubjectCoordinators = _db.SubjectCoordinators
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.SubjectCoID.ToString(),
                                      Text = a.Title
                                  })
                                  .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseCreate(Course obj)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("CourseIndex");
            }
            return View(obj);
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult CourseEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.SubjectCoordinators = _db.SubjectCoordinators
                                   .Select(a => new SelectListItem()
                                   {
                                       Value = a.SubjectCoID.ToString(),
                                       Text = a.Title
                                   })
                                   .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseEdit(Course obj)
        {
            _db.Courses.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("CourseIndex");
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult CourseDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseDelete(Course obj)
        {
            _db.Courses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("CourseIndex");
        }

        // modules in courses

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult CourseModIndex(int? id)
        {
            IEnumerable<Module_Course> objList = _db.Modules_Courses;

            ViewBag.course_id = id;

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult CourseModCreate(int? id)
        {
            var obj = new Module_Course();
            obj.Modules = _db.Modules
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.ModID.ToString(),
                                      Text = a.Name
                                  })
                                  .ToList();

            ViewBag.course_id = id;

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseModCreate(Module_Course obj)
        {
            if (ModelState.IsValid)
            {
                _db.Modules_Courses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("CourseIndex");
            }
            return View(obj);
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult CourseModDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Modules_Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseModDelete(Module_Course obj)
        {
            _db.Modules_Courses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("CourseIndex");
        }

        //modules

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult ModuleIndex()
        {
            IEnumerable<Module> objList = _db.Modules;

            return View(objList);
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult ModuleCreate()
        {
            var obj = new Module();
            obj.Lecturers = _db.Lecturers
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.LecturerID.ToString(),
                                      Text = a.Title
                                  })
                                  .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModuleCreate(Module obj)
        {
            if (ModelState.IsValid)
            {
                _db.Modules.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ModuleIndex");
            }
            return View(obj);
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult ModuleEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Modules.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.Lecturers = _db.Lecturers
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.LecturerID.ToString(),
                                      Text = a.Title
                                  })
                                  .ToList();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModuleEdit(Module obj)
        {
            _db.Modules.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("ModuleIndex");
        }

        [Authorize(Roles = "SuperAdmin, HeadOfDepartment")]
        public ActionResult ModuleDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Modules.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModuleDelete(Module obj)
        {
            _db.Modules.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("ModuleIndex");
        }
    }
}