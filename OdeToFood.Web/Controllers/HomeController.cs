using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Data.Services;
using OdeToFood.Data.Services.Repositories;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _fakeDb;

        public HomeController()
        {
            _fakeDb = new InMemoryRestaurantData();
        }

        public ActionResult Index()
        {
            var restaurants = _fakeDb.GetAll();
            return View(restaurants);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}