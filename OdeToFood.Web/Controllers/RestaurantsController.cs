using OdeToFood.Data.Services.Repositories;
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

        // GET
        public ActionResult Index()
        {
            var restaurants = _fakeDb.GetAll();
            return View(restaurants);
        }

        public ActionResult Create()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Edit(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Details(int id)
        {
            var restaurant = _fakeDb.GetRestaurant(id);

            if (restaurant == null)
            {
                return View("NotFound");
            }
            
            return View(restaurant);
        }

        public ActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}