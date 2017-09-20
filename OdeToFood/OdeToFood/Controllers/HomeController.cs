using OdeToFood.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _db = ApplicationDbContext.Create();

        //jQuery UI documentation on autocomplete features states that the browser
        //when the user is typing, it will send a request to the server, and that request
        //will include a parameter called term, which represents what the user has typed
        //so far
        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants.Where(r => r.Name.StartsWith(term))
                                        .Take(10)
                                        .Select(r => new
                                        {
                                            label = r.Name
                                        });

            return Json(model, JsonRequestBehavior.AllowGet);
            //documentation says the object JSON object returned should have a label property
            //or a value property, or both.
        }

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var model = _db.Restaurants.OrderByDescending(r => r.Reviews.Average(rv => rv.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select(r => new RestaurantListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Ian Gesner";
            model.Location = "Maryland, USA";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}