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

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id.Equals(id));
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var oldRestaurant = restaurants.SingleOrDefault(r => r.Id.Equals(restaurant.Id));

            if (oldRestaurant == null) return restaurant;

            oldRestaurant.Name = restaurant.Name;
            oldRestaurant.Location = restaurant.Location;
            oldRestaurant.Cuisine = restaurant.Cuisine;

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}