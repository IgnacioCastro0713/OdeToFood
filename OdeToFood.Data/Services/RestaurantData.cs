using OdeToFood.Data.Models;
using OdeToFood.Data.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class RestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public RestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant {Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(restaurant => restaurant.Name);
        }

        public Restaurant GetRestaurant(int id)
        {
            return _restaurants.Find(restaurant => restaurant.Id == id);
        }
    }
}