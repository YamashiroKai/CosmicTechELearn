using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example_Routing.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            return Ok("Action of Blog Controller is called");
        }
        //Attribute Routing 
        [Route("Blog")]
        [Route("Blog/Index")]
        [Route("Blog/Index/{id?}")]

        public IActionResult AnyActionName(int id)
        {
            return Ok("Index Called {id}" +id);
        }

        
    }
}
