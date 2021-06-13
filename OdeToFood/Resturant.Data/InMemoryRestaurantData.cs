using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> Restaurants;
        public InMemoryRestaurantData()
        {
            var restaurants = new List<Restaurant>()
            {
                Restaurant.Default,
                Restaurant.Default,
                Restaurant.Default,
                Restaurant.Default,
                Restaurant.Default,
                Restaurant.Default,
                Restaurant.Default,
                Restaurant.Default,
                Restaurant.Default,
                Restaurant.Default,
            };
            var res = from r in restaurants
                      orderby r.Name
                      select r;
            Restaurants = res.ToList();
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return Restaurants;
        }

        public IEnumerable<Restaurant> GetResturantsByName(string name)
        {
            var res = GetAll();
            if(name != null)
            {
               res = res.Where(r => r.Name.StartsWith(name,StringComparison.OrdinalIgnoreCase));
            }
            return res;
        }

        public Restaurant GetResturantsById(int id)
        {
            var res = GetAll();
            return res.Where(r => r.Id == id).FirstOrDefault();
            //return res;
        }

        public Restaurant UpdateResturant(Restaurant restaurant)
        {
            //GetAll().Select((r,i) =>
            //{
            //    if (r.Id == restaurant.Id)
            //    {
            //        r.Name = restaurant.Name;
            //        r.Location = r.Location;
            //        r.Alias = r.Alias;
            //    }
            //    return r;
            //});
            //return GetResturantsById(restaurant.Id);
            var r = Restaurants.FirstOrDefault(r => r.Id == restaurant.Id);
            if (r.Id == restaurant.Id)
            {
                r.Name = restaurant.Name;
                r.Location = restaurant.Location;
                r.Alias = restaurant.Alias;
            }
            return r;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            newRestaurant.Id = Restaurants.Max(r => r.Id)+1;
            Restaurants.Append(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return Restaurants.Count();
        }
    }
}
