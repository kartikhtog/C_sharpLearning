using System;
using System.Collections.Generic;
using System.Text;

namespace skills.NullObjectPattern
{
    /// <summary>
    /// pattern to remove and reduce the amount of null references and thus reduce the burden of 
    /// repetitive null checking
    /// </summary>
    public class NullObjectPattern
    {
        public NullObjectPattern()
        {
            var o1 = new ClassUsesAbstraction(new ConcreteClass1());
            o1.DoSomething();
            var o2 = new ClassUsesAbstraction(new ConcreteClass2());
            o2.DoSomething();
            var o3 = new ClassUsesAbstraction(null);
            try
            {
                o3.DoSomething();
            }
            catch (Exception e)
            {
                Console.WriteLine("null pointer exception");
            }

            var o4 = new ClassUsesAbstraction(new ConcreteNullClass());
            // no exception ... a default or null class implements methods with "default" behaviour
            o4.DoSomething(); 

            // or do something like this ... better
            var o5 = new ClassUsesAbstraction(IAbstraction.Null);
            o5.DoSomething(); 

        }
    }
}
