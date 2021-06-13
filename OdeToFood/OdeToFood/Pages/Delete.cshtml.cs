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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData _RestaurantData;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this._RestaurantData = restaurantData;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Restaurant = restaurantId.HasValue ? _RestaurantData.GetResturantsById(restaurantId.Value) : null;
            
            if (Restaurant == null)
            {
                return RedirectToPage("./Resturants");
            }
            return Page();
        }
        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = _RestaurantData.Delete(restaurantId);
            _RestaurantData.Commit();
            return RedirectToPage("./Resturants");
        }
    }
}
