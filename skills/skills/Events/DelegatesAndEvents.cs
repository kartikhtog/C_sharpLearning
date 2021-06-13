using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace skills.Events
{
    public class DelegatesAndEvents
    {
        public delegate void WorkPreformedHandler(int i);

        /// <summary>
        /// WorkPreformedHandler is a delegate
        /// WorkPreformed is the name
        /// When listener add this event
        /// what they are really doing is adding to invocation list of the delegate
        ///
        /// </summary>
        public event WorkPreformedHandler WorkPerformed;

        // that was enough but you also expend if you want like this
        private WorkPreformedHandler _WorkPerformed2;
        public event WorkPreformedHandler WorkPerformed2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                // does the same thing ... but you could modify it
                _WorkPerformed2 = (WorkPreformedHandler)Delegate.Combine(
                    _WorkPerformed2, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _WorkPerformed2 = (WorkPreformedHandler)Delegate.Remove(
                    _WorkPerformed2, value);
            }

        }
    }
}
