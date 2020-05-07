using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services.Repositories.Implemantations
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAll();

        Task<Restaurant> GetOne(int id);

        Task Add(Restaurant restaurant);
        Task Update(Restaurant restaurant);

        Task Delete(int id);
    }
}