using OdeToFood.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    [Log]
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Search(string name)
        {
            var param = Server.HtmlEncode(name);
            return Content(param);
        }
    }
}