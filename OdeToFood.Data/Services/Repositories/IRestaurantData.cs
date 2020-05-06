using System.Collections.Generic;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services.Repositories
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant GetOne(int id);

        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
    }
}