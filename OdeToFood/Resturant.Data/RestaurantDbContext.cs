using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resturant.Data
{
    /// <summary>
    /// Database context
    /// DbContext... create properties that you want to add to the datebase
    /// </summary>
    /// 
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            :base(options)
        {

        }
        /// <summary>
        /// Dbset tells entity framework that we not only want to insert but able delete, edit and set
        /// </summary>
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
