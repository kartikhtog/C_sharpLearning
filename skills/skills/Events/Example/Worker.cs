using System;
using System.Collections.Generic;
using System.Text;

namespace skills.Events.Example
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);
    public class Worker
    {

        public event WorkPerformedHandler WorkPreformed;
        /// <summary>
        /// EventHandler is itself a Delegate with specific parameters
        /// (object? sender, EventArgs e)
        /// </summary>
        public event EventHandler WorkCompleted;

        // need to create delegate that looks like EventHandler
        // these to two next lines are same as the following
        public delegate void WorkPerformedHandler2(object sender, WorkCompletedEventArgs args);
        public event WorkPerformedHandler2 WorkCompleted2;
        
        // this is same... syntactic sugar... yum
        // creates a delegate with that looks like ^^^ but we don't have to write that stub
        public event EventHandler<WorkCompletedEventArgs> WorkCompleted3;

        public virtual void DoWork(int hours, WorkType workType)
        {
            // how do we invoke
            // first way
            if (WorkPreformed != null) // check if the invocation list is zero
            {
                WorkPreformed(1, WorkType.city);
            }
            // second way ... the event type is a delegate
            WorkPerformedHandler del = WorkPreformed as WorkPerformedHandler;
            if (del != null)
            {
                del(2, WorkType.city);
            }

            // third way
            OnWorkPreformed(3, WorkType.city);
            /// Fouth way
            /// do this... generally accepted good practice
            OnWorkCompleted2(1, WorkType.city);
        
        }
        /// <summary>
        /// Some people use "Raise" keywork instead of "On"
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="w"></param>
        protected virtual void OnWorkPreformed(int hours, WorkType w)
        {
            if (WorkPreformed != null)
            {
                WorkPreformed(hours, w);
            }
        }
        protected virtual void OnWorkCompleted(int hours, WorkType w)
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
                // EventArgs.Empty uses the null object pattern is seems like
            }  
            if (WorkCompleted != null)
            {
                // now you can use pass in bad values but it not recomended
                //WorkCompleted(null, null);
            }
        }      
        protected virtual void OnWorkCompleted2(int hours, WorkType w)
        {
            if (WorkCompleted2 != null)
            {
                /// both are the same
                WorkCompleted2(this, new WorkCompletedEventArgs(hours, w ));
                // this approach is cleaner
                WorkCompleted3(this, new WorkCompletedEventArgs(hours, w ));
            }
        }
    }

    public enum WorkType
    {
        road,
        city,
    }

    /// <summary>
    /// If you many args that you want to pass this is much easier
    /// So this is standard practice
    /// </summary>
    public class WorkCompletedEventArgs : EventArgs
    {
        public WorkCompletedEventArgs(int hours, WorkType workType)
        {
            Hours = hours;
            WorkType = workType;
        }
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}
