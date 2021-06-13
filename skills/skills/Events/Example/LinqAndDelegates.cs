using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace skills.Events.Example
{
    class Person
    {
        public string Name;
        public int Age;
        public int Id;
        public string Alias;
        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Age: {2}, Alias: {3}", Id, Name, Age, Alias);
        }
    }
    public class LinqAndDelegates
    {
        public LinqAndDelegates()
        {
            var people = new List<Person>
            {
                new Person{Name="num",Age=11,Alias="ber",Id=1},
                new Person{Name="kar",Age=10,Alias="tik",Id =2},
                new Person{Name="rak",Age=9,Alias="la",Id =3},
                new Person{Name="rak",Age=9,Alias="la",Id =4},
            };

            // where accept a func where parameter is func and result it bool
            var ageMoreThan9 = people.Where(p => p.Age > 9);
            foreach (var person in ageMoreThan9)
            {
                Console.WriteLine(person);
            }
            var sortedByAge = people.OrderBy(p => p.Age);
            foreach (var person in sortedByAge)
            {
                Console.WriteLine(person);
            }
            var subSetOrdered = people
                .Where(p => p.Age > 8)
                .OrderBy(p => p.Age);

        }
    }
}
