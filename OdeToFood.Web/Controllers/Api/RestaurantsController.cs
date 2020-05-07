using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using OdeToFood.Data.Models;
using OdeToFood.Data.Services.Repositories.Implemantations;

namespace OdeToFood.Web.Controllers.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantsController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Restaurant>> Index()
        {
            return await _restaurantRepository.GetAll();
        }
    }
}