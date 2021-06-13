using System;
using System.Collections.Generic;
using System.Text;

namespace skills.NullObjectPattern
{
    class ConcreteNullClass : IAbstraction
    {
        public int ReturnSomething(int SomeParameter)
        {
            // A sensiable do nothing behaviour
            return 0;
        }
    }
}
