using OdeToFood.Data.Models;
using OdeToFood.Data.Services.Repositories;
using OdeToFood.Web.Models.ViewModels;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData _fakeDb;

        public RestaurantsController(IRestaurantData fakeDb)
        {
            _fakeDb = fakeDb;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var restaurants = _fakeDb.GetAll();
            return View(restaurants);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("RestaurantForm", new RestaurantFormViewModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(RestaurantFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("RestaurantForm");
            }

            var restaurant = new Restaurant {Name = viewModel.Name, Cuisine = viewModel.Cuisine};
            _fakeDb.Add(restaurant);

            return RedirectToAction("Details", new {id = restaurant.Id});
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var restaurant = _fakeDb.GetOne(id);

            if (restaurant == null)
            {
                return View("NotFound");
            }

            var viewModel = new RestaurantFormViewModel
            {
                Name = restaurant.Name,
                Cuisine = restaurant.Cuisine,
                Id = restaurant.Id
            };

            return View("RestaurantForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(RestaurantFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("RestaurantForm");
            }

            var restaurant = new Restaurant {Name = viewModel.Name, Cuisine = viewModel.Cuisine, Id = viewModel.Id};

            _fakeDb.Update(restaurant);

            return RedirectToAction("Details", new {id = restaurant.Id});
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var restaurant = _fakeDb.GetOne(id);

            return restaurant == null ? View("NotFound") : View(restaurant);
        }

        public ActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}