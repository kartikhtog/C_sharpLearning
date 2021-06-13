using skills.Events.Example;
using System;
using System.Collections.Generic;
using System.Text;

namespace skills.Events
{
    /// <summary>
    /// Lets go over Events, Delegates and Event Handlers, EventArgs ..
    /// Lambdas, Action and etc..
    /// </summary>
    public class ThreadsAndEvents
    {
        public ThreadsAndEvents()
        {
            //var delegateStuff = new DelegateStuff();
            //var w = new Listener();
            //var w = new DelegateLogicToAnotherPlace();
            //var w = new ActionAndFuncOfTDelegate();
            var w = new LinqAndDelegates();

        }
    }
}


/*
 * Notes: 
 * 1. A delegate is specialized class often called a "Function Pointer"
 *    Based on a MulticastDelegate base class
 * 2. A Event handler is responsible for receiving and processing data from a delegate
 *    Two parameters: sender and eventArgs(responsible for encapsulating event data)
 *    
 * **/