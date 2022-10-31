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
    public class SubjectCoordinatorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SubjectCoordinatorController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
        public ActionResult Index()
        {
            ViewBag.own_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<SubjectCoordinator> objList = _db.SubjectCoordinators;

            if (!String.IsNullOrEmpty(ViewBag.own_id))
                objList = objList.Where(s => s.Id.Contains(ViewBag.own_id));

            return View(objList);
        }

        // Register

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
        public ActionResult Register()
        {
            var obj = new SubjectCoordinator();
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
        public ActionResult Register(SubjectCoordinator obj)
        {
            _db.SubjectCoordinators.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
        public ActionResult EditDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.SubjectCoordinators.Find(id);
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
        public ActionResult EditDetails(SubjectCoordinator obj)
        {
            _db.SubjectCoordinators.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        // Material

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
        public ActionResult MatIndex(string sortOrder, string searchString, string mod_id)
        {
            ViewBag.SortWeek = String.IsNullOrEmpty(sortOrder) ? "week_desc" : "";
            ViewBag.SortMod = sortOrder == "mod_asc" ? "mod_desc" : "mod_asc";
            ViewBag.SortApproved = sortOrder == "approved_asc" ? "approved_desc" : "approved_asc";
            ViewBag.ModID = mod_id;
            ViewData["CurrentFilter"] = searchString;

            IEnumerable<Material> objList = _db.Materials;

            if (!String.IsNullOrEmpty(searchString))
            {
                objList = objList.Where(s => s.ModID.Equals(searchString));
            }

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

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
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

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
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

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
        public ActionResult SubIndex(string sortOrder, string searchString)
        {
            ViewBag.SortWeek = String.IsNullOrEmpty(sortOrder) ? "week_desc" : "";
            ViewBag.SortMod = sortOrder == "mod_asc" ? "mod_desc" : "mod_asc";
            ViewBag.SortDue = sortOrder == "due_asc" ? "due_desc" : "due_asc";
            ViewBag.SortStart = sortOrder == "start_asc" ? "start_desc" : "start_asc";

            IEnumerable<Submission> objList = _db.Submissions;

            if (!String.IsNullOrEmpty(searchString))
                objList = objList.Where(s => s.ModID.Equals(searchString));

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

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
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

        [Authorize(Roles = "SuperAdmin, SubjectCoordinator")]
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
    }
}
