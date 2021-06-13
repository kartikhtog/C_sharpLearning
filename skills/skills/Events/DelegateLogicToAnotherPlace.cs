using System;
using System.Collections.Generic;
using System.Text;

namespace skills.Events
{

    public class DelegateLogicToAnotherPlace
    {
        public DelegateLogicToAnotherPlace()
        {
            var process = new ProcessData();
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate mullDel = (x, y) => x * y;
            BizRulesDelegate sub = (x, y) => x - y;
            BizRulesDelegate devide = (x, y) => x / y;
            Action<int,int> writeLineDel = (x, y) => Console.WriteLine(x+y);
            Func<int, int, bool> isSumPositiveDel = (x, y) => {
                if (x + y > 0) { return true; }
                else return false;
            };

            //x_para_type , y_para_type, return type
            process.Process(1, 1, addDel);
            process.Process2(1, 1, writeLineDel);
            var value = process.Process3(-2, 1, isSumPositiveDel);
            Console.WriteLine(value);
        }

    }
    public delegate int BizRulesDelegate(int x, int y);
    public class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate bizRulesDelegate)
        {
            var result = bizRulesDelegate(x, y);
            Console.WriteLine(result);
        }
        public void Process2(int x, int y, Action<int,int> action)
        {
            action(x, y); // but no return type :(
        }
        public bool Process3(int x, int y, Func<int,int,bool> func)
        {
            return func(x, y); // return the value
        }
    }






    // Action<T> is a delegate which accepts a single parameter and returns no value
    // but there is also Action<T,......> which acccept multiple parameters but still no return type
    // Func<T,TResult> is a delegate which accepts a single paramter and return a value of type TResult



    public class ActionAndFuncOfTDelegate
    {
        private delegate void GiveMeAMessage(string message);
        public ActionAndFuncOfTDelegate()
        {
            var del = new GiveMeAMessage(ShowMessage);
            del("Invoking Actions!");

            // same thing without create a delegate explicitly
            Action<string> messageTarget = ShowMessage;
            messageTarget("Invoking Actions!");
        }

        private void ShowMessage(string message) => Console.WriteLine(message);

        /// ok lets go somthing cool
    }
}