using System.Collections.Generic;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services.Repositories
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant GetRestaurant(int id);
    }
}