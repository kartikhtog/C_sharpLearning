using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturant;
using Resturant.Data;

namespace OdeToFood.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _RestaurantData;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public EditModel(IRestaurantData restaurantData)
        {
            _RestaurantData = restaurantData;
        }
        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
            {
                Restaurant = _RestaurantData.GetResturantsById(id.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./Resturants");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Restaurant.Id <= 0)
            {
                _RestaurantData.AddRestaurant(Restaurant);
            }
            else
            {
                Restaurant = _RestaurantData.UpdateResturant(Restaurant);
            }
            _RestaurantData.Commit();
            return RedirectToPage("./Resturants");
        }
    }
}
