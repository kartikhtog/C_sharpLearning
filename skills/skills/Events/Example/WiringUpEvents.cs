using System;
using System.Collections.Generic;
using System.Text;
namespace skills.Events.Example
{
    public class WiringUpEvents
    {

        public event EventHandler<WorkEventArgs> WorkCompleted;

        public virtual void DoWork()
        {
            OnWorkCompleted(1, WorkType.city);

        }
        protected virtual void OnWorkCompleted(int hours, WorkType w)
        {
            if (WorkCompleted != null)
            {
                WorkCompleted(this, new WorkEventArgs(hours, w));
            }
        }
    }

    /// <summary>
    /// If you many args that you want to pass this is much easier
    /// So this is standard practice
    /// </summary>
    public class WorkEventArgs : EventArgs
    {
        public WorkEventArgs(int hours, WorkType workType)
        {
            Hours = hours;
            WorkType = workType;
        }
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }

    public class Listener
    {
        public Listener()
        {
            var worker = new WiringUpEvents();
            
            /// create another delegate and add it to invocation list
            worker.WorkCompleted += new EventHandler<WorkEventArgs>(ListenToWorker);
            
            // delegate inference
            // we can also go this.... syntactic sugar ... the complier will create the delegate for us
            worker.WorkCompleted += ListenToWorker;

            // try worker.WorkCompleted +=<tab><tab> // auto complete
            

            // can also remove it
            worker.WorkCompleted -= ListenToWorker;

            // can also do anon method 
            worker.WorkCompleted += delegate(object s,WorkEventArgs e)
            {
                Console.WriteLine(e.WorkType);
            };

            // can also do anon method with lambdas
            worker.WorkCompleted += (s, e)=> Console.WriteLine(e.WorkType);
            
            worker.DoWork();
        }

        private void ListenToWorker(object sender, WorkEventArgs e)
        {
            Console.WriteLine(e.WorkType);
        }

    }

}
