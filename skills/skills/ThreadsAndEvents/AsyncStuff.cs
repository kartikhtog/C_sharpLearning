using System;
using System.Collections.Generic;
using System.Text;

namespace skills.ThreadsAndEvents
{
    class AsyncStuff
    {
        delegate void UpdateProgressDelegate(int val);
        private void Clicked(object sender, EventArgs e)
        {
            var progDel = new UpdateProgressDelegate(StartProcess);

            // begininvoke (async on a threadpool) vs invoke (called on same thread syncronously)
            // this will called on the secondary thread
            progDel.BeginInvoke(100,null,null); 
        }
        private void StartProcess(int max)
        {
            int[] arr = { 1, 2, 2, 3, 4, 5 };
            foreach (var i in arr)
            {
                Console.WriteLine(max);
            }
        }
    }
}
