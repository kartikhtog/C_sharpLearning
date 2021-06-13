using System;
using System.Collections.Generic;
using System.Text;

namespace skills.NullObjectPattern
{
    public class ClassUsesAbstraction
    {
        public readonly IAbstraction _abstraction;
        public ClassUsesAbstraction(IAbstraction abstraction)
        {
            _abstraction = abstraction;
        }
        public int someValue { get; set; } = 100;
        public void DoSomething()
        {
            someValue =- _abstraction.ReturnSomething(5);
            Console.WriteLine("The result is {0}", someValue);
        }
    }
}
