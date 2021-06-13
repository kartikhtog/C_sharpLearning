using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Resturant;
using Resturant.Data;

namespace OdeToFood.Pages
{
    public class ResturantsModel : PageModel
    {
        private readonly IConfiguration _Configuration;
        private readonly IRestaurantData _RestaurantsData;

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public string Message { get; set; }
        public IEnumerable<Restaurant> restaurants{ get; set; }

        public ResturantsModel(IConfiguration configuration, IRestaurantData resturantData)
        {
            _RestaurantsData = resturantData;
            _Configuration = configuration;
        }
        // can do this or modify OnGet() to OnGet(string searchTerm) // the searchTerm must match
        //HttpContext.Request.Query.ContainsKey("searchTerm");
        //public void OnGet()
        // if asp.net does not find searchTerm it will pass in null
        public void OnGet()
        {
            Message = _Configuration["Message"];
            restaurants = _RestaurantsData.GetResturantsByName(SearchTerm);
        }
    }
}
