using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example_Routing.Data;
using Example_Routing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example_Routing.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDBContext _db;//Our db context which as access to the DbSet

        public ExpenseController(ApplicationDBContext db)
        {
            _db = db; 
        }
        public IActionResult Index()//This is the page to load the expenses data on the Index page 
        {
            IEnumerable<Expense> objList = _db.Expenses;//Coming from our database
            return View(objList);
        }

        //Get-Create- taking us to the Create page to add new expenses 
        public IActionResult Create()
        {

            return View();
        }


        //POST-Create- Inserting new expense data 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET-Update

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            _db.Expenses.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}
