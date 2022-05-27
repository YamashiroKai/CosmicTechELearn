using Example_Routing.Data;
using Example_Routing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example_Routing.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ItemController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;//Coming from our database
            return View(objList);
        }

        //GET Method returning the Create.cshtml
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if(ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }




    }
}
