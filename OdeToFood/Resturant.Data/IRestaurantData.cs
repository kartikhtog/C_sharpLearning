using System.Collections.Generic;
using System.Text;

namespace Resturant.Data
{
    // Added nuget package entityframeworkcore 
    // Added nuget package entityframeworkcore.sqlserver 
    // Added nuget package entityframeworkcore.design 

    // dotnet command line tools
    // dotnet tool install --global dotnet-ef
    // use with dotnet-ef

    //dotnet-ef dbcontext list <- running this should give the following
    //Resturant.Data.RestaurantDbContext
    // it found your context
    //dotnet-ef dbcontext info <- generates error ... not attached to a real database
    // lcoal SQL server is installed with visual studios
    // View >  sql server object Explorer
    // you will see the localdb

    /*In appsetting.json
     * Initial Catalog is the specific database where it will look for.
     * Integrated Security=True ... credentials to connect to db... for local we don't need much
     * "ConnectionStrings": {
    "RestaurantDb": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Restaurant;Integrated Security=True"
  },*/

    // create the database .. with information about where the databases in OdeToFood
    //dotnet-ef dbcontext info -s ../OdeToFood/OdeToFood.csproj

    // adds a migration ... creats a migration folder
    // dotnet-ef migrations add initalcreate -s ../OdeToFood/OdeToFood.csproj

    // apply the migration
    //dotnet-ef database update -s ../OdeToFood/OdeToFood.csproj

    // Data is stored in >> Databases >> Restarant >> right click dbo.Restaurants and click video data


    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetAll();
        public IEnumerable<Restaurant> GetResturantsByName(string name);
        public Restaurant GetResturantsById(int id);
        /// <summary>
        /// The "Id" is the key
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        public Restaurant UpdateResturant(Restaurant restaurant);

        public Restaurant AddRestaurant(Restaurant newRestaurant);

        Restaurant Delete(int id);

        int GetCountOfRestaurants();

        int Commit();
    }
}
