#nullable enable
// to enable nullable project wide add to cproj file
// <Nullable>enable<Nullable>
// this will just generate warnings
// if we want to turn this errors and fail the build ... add the warning to errors list in Propeties>Build>Treat warning as errors
using System;
using System.Collections.Generic;
using System.Text;

namespace skills.NonNullable
{
    /// <summary>
    ///  If the reference type should always have a value
    /// </summary>
    class NonNullable
    {
        public NonNullable()
        {
            string message = null; /// gives us warning
            Console.WriteLine(message);

            string? message2 = null; /// make it nulllable type for no warning
            Console.WriteLine(message2);

            var o = new RandomClass();
            Console.WriteLine(o.aString.Length); // givens us warning that we may be derefence a null
           
            var o2 = new RandomClass();
            // null forgiving operator ... we know that the value will be valid
            // careful when using it
            Console.WriteLine(o2.aString!.Length);  
            
            var o3 = new RandomClass();
            o3.DoSomething(null); // given warning ,.... them method does not explicity take nulls
            o3.DoSomething2(null); // if fine the method accepts nulls
        }
    }

    public class RandomClass
    {
        public string? aString { get; set; } = "1";
        public RandomClass()
        {

        }
        public void DoSomething(string something)
        {

        }
        public void DoSomething2(string? something)
        {

        }
    }
}

