using OdeToFood2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood2.Controllers
{
    [Log]
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        [HttpPost]
        public ActionResult Search(string name = "Cuban")
        {
            //var name = RouteData.Values["name"];
            var message = Server.HtmlEncode(name);

            return Content(String.Format("Hello {0} Cuisine!!", name));

            //return RedirectToAction("Index", "Home", new { name = name });

            //return File(Server.MapPath("~/Content/Site.css"), "text/css");

            //return Json(new { message = "Cuisine " + message, name = "Chef Osmany" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Search()
        {
            //var name = RouteData.Values["name"];

            throw new Exception("Something terrible has happend!!");

            return Content("Get Cuisine Search!!");

        }

    }
}
