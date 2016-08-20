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
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = String.Format("{0}::{1} {2}", controller, action, id);

            ViewBag.Message = message;

            return View();
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
    }
}
