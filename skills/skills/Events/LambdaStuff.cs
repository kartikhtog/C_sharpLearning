using System;
using System.Collections.Generic;
using System.Text;

namespace skills.Events
{
    public class LambdaStuff
    {
        delegate int AddDelegate(int a, int b);
        public LambdaStuff()
        {
            AddDelegate ad = (a, b) => a + b;// the return is infered by the complier
            int result = ad(1, 1);
        }
    }
}
