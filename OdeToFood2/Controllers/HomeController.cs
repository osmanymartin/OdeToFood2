using OdeToFood2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood2.Controllers
{
    public class HomeController : Controller
    {

        OdeToFood2Db _db = new OdeToFood2Db();

        public ActionResult Index(string searchTerm = null)
        {
            var model = _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(re => re.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Take(10)
                .Select(res =>
                    new RestaurantListViewModel
                    {
                        Id = res.Id,
                        Name = res.Name,
                        City = res.City,
                        Country = res.Country,
                        CountOfReviews = res.Reviews.Count()
                    });
            //.ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }


            return View(model);


            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var id = RouteData.Values["id"];

            //var message = String.Format("{0}::{1} {2}", controller, action, id);

            //ViewBag.Message = message;

        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";
            //ViewBag.Location = "Miami, FL.";

            var model = new AboutModel();
            model.Name = "Osmany San Martin";
            model.Location = "33145, Miami, FL.";

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
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
