using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Data.Services;
using OdeToFood.Data.Services.Repositories.Implemantations;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public HomeController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ActionResult> Index()
        {
            var restaurants = await _restaurantRepository.GetAll();
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