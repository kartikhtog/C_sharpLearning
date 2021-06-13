using System;
using System.Collections.Generic;
using System.Text;

namespace skills.Events
{
    public class DelegateStuff
    {
        /// <summary>
        /// Delegate ... stub for method .. blueprint for data to get dumped. The delegate delegates work to handler method with same parameters
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="s"></param>
        public delegate void WorkPerformedHandler(int hours, string s);

        /// <summary>
        /// A bidirectional delegate
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public delegate int WorkPerformedHandler2(int hours, string s);

        public static void Manager_WorkPerformed(int hours, string s)
        {
            Console.WriteLine("Manager_WorkPerformed called");
        }

        public static void Manager_WorkPerformed2(int hours, string s)
        {
            Console.WriteLine("Manager_WorkPerformed2 called");
        }

        public static void Manager_WorkPerformed3(int hours, string s)
        {
            Console.WriteLine("Manager_WorkPerformed3 called");
        }
        public static int Manager_WorkPerformed4(int hours, string s)
        {
            Console.WriteLine("Manager_WorkPerformed4 called");
            return 1;
        }

        public DelegateStuff()
        {
            // --> workProformedHandler is drived class MulticastDelegate.. which accepts a method of that stub(or signature)
            var del1 = new WorkPerformedHandler((i, j) => {});
            del1(1, "S"); // invokes the delegate

            // but we just pass in function too 
            var del2 = new WorkPerformedHandler(Manager_WorkPerformed);
            del2(1, "S"); // now the function will be invoked instead of annon method.

            // what if want to invoke multiple methods with same delegate.
            var del3 = new WorkPerformedHandler(Manager_WorkPerformed2);
            
            // what if want to invoke multiple methods with same delegate.
            var del4 = new WorkPerformedHandler(Manager_WorkPerformed3);

            // we can add to the invocation delegate list of delegate
            del2 += del3; // syntactic sugar
            /// also can do del2 = del2 + del3 + del4
            del2(1, "s");// will invoke both in sequence
            // what is advantage calling delegate insteam of the function?... is this...
            // you can invoke the delegate without knowning the function once you added to the list
            // or can dynamically call different delegate depending on your code path... cleaner code. 


            var del5 = new WorkPerformedHandler2(Manager_WorkPerformed4);
            
            int someValue = del5(1, "s");// we can get value back from the delegate
            // if you multiple multiple , in the invocation list, only one returns value
        }
    }
}


/* Delegate Base Classes
 *  Delegate - method, target , getInvocationList()
 * MulticastDelegate (list of delegates) ---> Delegate :
 * Custom Delegate ----> MulticastDelegate
 * .... these are very specific bases classed that complier block you from driving... they you use it is by using the "delegate" key word
 * 
 * **/