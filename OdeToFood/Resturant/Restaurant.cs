using System;
using System.ComponentModel.DataAnnotations;

namespace Resturant
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Location { get; set; }

        public Restaurant ChangeId(int id)
        {
            Id = id;
            return this;
        }
        private static string generatorName = "Name";
        private static string generatorAlias = "Alias";
        private static string generatorLocation = "Location";
        private static int generatorAdded = 1;
        public static Restaurant Default { get {
                if (generatorAdded > 10)
                {
                    generatorAdded = 1;
                }
                return new Restaurant
                {
                    Id = generatorAdded,
                    Name = generatorName + generatorAdded,
                    Alias = generatorAlias + generatorAdded,
                    Location = generatorLocation + generatorAdded++,
                };
                //return new Restaurant
                //{
                //    Id = -1,
                //    Name = Guid.NewGuid().ToString(),
                //    Alias = Guid.NewGuid().ToString(),
                //    Location = Guid.NewGuid().ToString(),
                //};
            }
        }
    }
}
