using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantRepository : IRestaurantRepository
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantRepository()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Id = 0, Name = "Burger Place", Cuisine = CuisineType.None, Location = "New York"},
                new Restaurant(){ Id = 1, Name = "Lou's Pizzeria", Cuisine = CuisineType.Italian, Location = "Burgas"},
                new Restaurant(){ Id = 2, Name = "Kebab World", Cuisine = CuisineType.Indian, Location = "Whatever"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = "")
        {
            return string.IsNullOrEmpty(name) ? GetAll() : restaurants.FindAll(restaurant => restaurant.Name.StartsWith(name));
        }
    }
}