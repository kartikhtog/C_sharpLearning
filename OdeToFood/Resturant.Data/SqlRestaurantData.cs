using System.Collections.Generic;
using System.Linq;
namespace Resturant.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext db;

        public SqlRestaurantData(RestaurantDbContext db)
        {
            this.db = db;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetResturantsById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.AsEnumerable();
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public Restaurant GetResturantsById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetResturantsByName(string name)
        {
            // the same
            //var res = db.Restaurants.Where(r =>
            //    (r.Name.StartsWith(name) || string.IsNullOrEmpty(name)))
            //    .OrderBy(r => r.Id);

            //return res;

            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant UpdateResturant(Restaurant restaurant)
        {
            // attach tells the entity framework that I going to give an object that
            // is already in the database but I going to give this object I want to track the changes about this object
            // db can manage that object (entity)
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return restaurant;
        }
    }
}
