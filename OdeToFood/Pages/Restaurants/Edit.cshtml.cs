﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> CuisinesItems { get; set; }

        public EditModel(IRestaurantRepository restaurantRepository, IHtmlHelper htmlHelper)
        {
            this.restaurantRepository = restaurantRepository;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int id)
        {
            CuisinesItems = htmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = restaurantRepository.GetRestaurantById(id);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Restaurant = restaurantRepository.Update(Restaurant);
            restaurantRepository.Commit();

            return Page();
        }
    }
}