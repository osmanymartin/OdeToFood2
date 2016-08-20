using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood2.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        public ActionResult Search(string name = "Cuban")
        {
            //var name = RouteData.Values["name"];
            var message = Server.HtmlEncode(name);

            return Content(String.Format("Hello {0} Cuisine!!", name));

        }

    }
}
