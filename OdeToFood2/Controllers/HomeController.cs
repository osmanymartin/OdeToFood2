﻿using OdeToFood2.Models;
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

        public ActionResult Index()
        {
            var model = _db.Restaurants.ToList();

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
