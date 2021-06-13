using skills.Events;
using skills.Nullable;
using System;

namespace skills
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EventStuff();
        }

        static void EventStuff()
        {
            //var eventStuff = new EventsAndEtc();
            var eventStuff = new ThreadsAndEvents.ThreadsAndEvents();
        }
        static void NullStuff()
        {
            //var doNull = new NullableSkill();
            //var doNull = new NullObjectPattern.NullObjectPattern();
            //var doNull = new NonNullable.NonNullable();

        }
    }
}
