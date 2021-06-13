using System;
using System.Collections.Generic;
using System.Text;

namespace skills.NullObjectPattern
{
    public class ConcreteClass1 : IAbstraction
    {
        public int ReturnSomething(int SomeParameter)
        {
            return 5;
        }
    }
}
