using System;
using System.Collections.Generic;
using System.Text;

namespace skills.ThreadsAndEvents
{
    /// <summary>
    /// /
    /// </summary>


    class ThreadsAndEvents
    {
        private void MediatorPattern()
        {
            Mediator.GetMediator().Changed += (s, e) =>
            {
                Console.WriteLine("changed");
            };
            // loose coupling... they don't need to know about each other
            Mediator.GetMediator().OnChanged(this, new Job());
        }

        public ThreadsAndEvents()
        {
            //MediatorPattern();

        }
    }
}
