using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;

        private readonly IRestaurantRepository repository;

        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }  

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantRepository repository)
        {
            this.configuration = configuration;
            this.repository = repository;
        }

        public void OnGet()
        {
            Message = configuration["Message"];
            Restaurants = repository.GetRestaurantsByName(SearchTerm);
        }
    }
}