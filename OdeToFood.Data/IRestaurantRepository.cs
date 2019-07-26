using System.Collections;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetRestaurantById(int id);

        Restaurant Update(Restaurant restaurant);

        int Commit();
    }
}