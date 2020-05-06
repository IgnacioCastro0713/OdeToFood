using System;
using System.Collections.Generic;
using System.Web.Http;
using OdeToFood.Data.Models;
using OdeToFood.Data.Services.Repositories;

namespace OdeToFood.Web.Controllers.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData _fakeDb;

        public RestaurantsController(IRestaurantData fakeDb)
        {
            _fakeDb = fakeDb;
        }
        
        [HttpGet]
        public IEnumerable<Restaurant> Index()
        {
            return _fakeDb.GetAll();
        }
    }
}