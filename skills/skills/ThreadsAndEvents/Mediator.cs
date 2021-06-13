using System;
using System.Collections.Generic;
using System.Text;

namespace skills.ThreadsAndEvents
{
    // sealed cannot override
    sealed class Mediator
    {
        private static readonly Mediator _Instance = new Mediator();
        private Mediator() { }

        public static Mediator GetMediator()
        {
            return _Instance;
        }

        public event EventHandler<EventArgs1> Changed;

        public void OnChanged(object sender, Job job)
        {
            Changed(sender, new EventArgs1 { Job = job });
        }
        // could do the following if think the sender is this mediator
        //public void OnChanged(Job job)
    }

    public class Job
    {
    }

    public class EventArgs1 :EventArgs
    {
        public Job Job;
    }
}
