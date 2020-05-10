using OdeToFood.Data.Models;
using OdeToFood.Data.Services.Repositories.Implemantations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly OdeToFoodDbContext _context;

        public RestaurantRepository(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return await _context.Restaurants.OrderBy(restaurant => restaurant.Name).ToListAsync();
        }

        public async Task<Restaurant> GetOne(int id)
        {
            return await _context.Restaurants
                .FirstOrDefaultAsync(restaurant => restaurant.Id == id);
        }

        public async Task Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Restaurant restaurant)
        {
            var entry = _context.Entry(restaurant);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}