using OdeToFood.Data.Models;
using OdeToFood.Data.Services.Repositories.Implemantations;
using OdeToFood.Web.Models.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantsController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var restaurants = await _restaurantRepository.GetAll();
            return View(restaurants);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("RestaurantForm", new RestaurantFormViewModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(RestaurantFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("RestaurantForm");
            }

            var restaurant = new Restaurant {Name = viewModel.Name, Cuisine = viewModel.Cuisine};
            await _restaurantRepository.Add(restaurant);

            return RedirectToAction("Details", new {id = restaurant.Id});
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var restaurant = await _restaurantRepository.GetOne(id);

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
        public async Task<ActionResult> Update(RestaurantFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("RestaurantForm");
            }

            var restaurant = new Restaurant {Name = viewModel.Name, Cuisine = viewModel.Cuisine, Id = viewModel.Id};

            await _restaurantRepository.Update(restaurant);

            return RedirectToAction("Details", new {id = restaurant.Id});
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var restaurant = await _restaurantRepository.GetOne(id);

            return restaurant == null ? View("NotFound") : View(restaurant);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var restaurant = await _restaurantRepository.GetOne(id);

            return restaurant == null ? View("NotFound") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, FormCollection formCollection)
        {
            await _restaurantRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}