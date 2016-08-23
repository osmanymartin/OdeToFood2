using OdeToFood2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood2.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFood2Db _db = new OdeToFood2Db();

        //
        // GET: /Reviews/

        public ActionResult Index([Bind(Prefix = "id")] int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }

            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }

            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }


        //[ChildActionOnly]
        //public ActionResult BestReview()
        //{
        //    var bestReview = _reviews.OrderByDescending(r => r.Rating);

        //    return PartialView("_Review", bestReview.First());
        //}

        //static List<RestaurantReview> _reviews = new List<RestaurantReview>
        //{
        //    new RestaurantReview {
        //        Id=1,
        //        Name="Cassola Pizzeria",
        //        City="Miami",
        //        Country="USA",
        //        Rating=7
        //    },
        //    new RestaurantReview {
        //        Id=2,
        //        Name="Chusmita Pizzeria",
        //        City="Jaguey",
        //        Country="Cuba",
        //        Rating=10
        //    },
        //    new RestaurantReview {
        //        Id=3,
        //        Name="Roma Pizzeria",
        //        City="Milan",
        //        Country="Italy",
        //        Rating=9
        //    },
        //    new RestaurantReview {
        //        Id=4,
        //        //Name="<script>alert('Grrrrrrr catch you!!')</script>",
        //        Name="Versailles restaurant",
        //        City="Miami",
        //        Country="USA",
        //        Rating=8
        //    }
        //};
    }
}
