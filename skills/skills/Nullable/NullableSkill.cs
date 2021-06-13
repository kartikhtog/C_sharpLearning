using System;
using System.Collections.Generic;
using System.Text;

namespace skills.Nullable
{
    class Class1{
        public int? i =1;
        public override string ToString()
        {
            return String.Format("The value of innner int is {0}", i); ;
        }
    }
    class NullableSkill
    {
        public void FullForm()
        {

            Nullable<int> aVar = new Nullable<int>(1); /// valid on primative types
            if (aVar.HasValue)//=> aVar != null
            {
                Console.WriteLine("It was a value.");
                Console.WriteLine(String.Format("It has a value of {0}.",aVar.Value));
                Console.WriteLine(String.Format("It has a value or default value of {0}.",aVar.GetValueOrDefault()));
            }
            aVar = null;
            if (!aVar.HasValue) //
            {
                Console.WriteLine("It no longer has a value");
                Console.WriteLine(String.Format("It has a value or default value of {0}.",aVar.GetValueOrDefault()));
                Console.WriteLine(String.Format("It has a value or (supplied)default value(2) of {0}.",aVar.GetValueOrDefault(2)));
            }
        }
        public void ShortForm()
        {
            int nonNullInt = 2;
            int? aVar = nonNullInt; // also auto conversion happens to.
            aVar = 1; // assignment

            //nonNullInt = aVar;// this wont wortk
            nonNullInt = (int)aVar;// this will wortk
            nonNullInt = aVar.Value;// this will wortk
            Console.WriteLine("Non non int value {0}", nonNullInt);
            
            if (aVar.HasValue)//=> aVar != null
            {
                Console.WriteLine("It was a value.");
                Console.WriteLine(String.Format("It has a value of {0}.",aVar.Value));
                Console.WriteLine(String.Format("It has a value or default value of {0}.",aVar.GetValueOrDefault()));
            }
            aVar = null;
            if (!aVar.HasValue) //
            {
                Console.WriteLine("It no longer has a value");
                Console.WriteLine(String.Format("It has a value or default value of {0}.",aVar.GetValueOrDefault()));
                Console.WriteLine(String.Format("It has a value or (supplied)default value(2) of {0}.",aVar.GetValueOrDefault(2)));
            }

        }
        public void ConditionalOperator()
        {
            int? i = 1;
            var j = i.HasValue ? "has value" : "has no value";
            Console.WriteLine("the value of j is {0}",j);
            i = null;
            j = i.HasValue ? "has value" : "has no value";
            Console.WriteLine("the value of j is {0}",j);
        }

        /// <summary>
        /// returns the value of the obect if not null otherwise return other value
        /// </summary>
        public void NullCoelescingOperator()
        {
            var class1 = new Class1() {i=1}; // same with nullable of primative types
            class1 = class1 ?? new Class1() {i=2};
            Console.WriteLine(class1);
            class1 = null;
            class1 = class1 ?? new Class1() {i=2};
            Console.WriteLine(class1);
        }

        public void NullPropertiesOfNullObjects()
        {
            int? nullableInt;
            int nonNullableInt;
            var class1 = new Class1() {i=1}; 
            nullableInt = class1?.i; //
            nonNullableInt = class1?.i ?? 3;//class1?.i would not be valid as class? can return null
            Console.WriteLine("value of nullableInt is {0}", nullableInt);
            Console.WriteLine("value of nonNullableInt is {0}", nonNullableInt);      
            
            class1 = new Class1() {i= null}; 
            nullableInt = class1?.i; 
            nonNullableInt = class1?.i ?? 3; // able to check 2 nulls in one line. neat
            Console.WriteLine("value of nullableInt is {0}", nullableInt);
            Console.WriteLine("value of nonNullableInt is {0}", nonNullableInt);

            class1 = null; 
            nullableInt = class1?.i;
            nonNullableInt = class1?.i ?? 3; // didn't matter if object was null or i of object.. 3 both times
            Console.WriteLine("value of nullableInt is {0}", nullableInt);
            Console.WriteLine("value of nonNullableInt is {0}", nonNullableInt);

        }

        public void NullInArray()
        {
            // notice that there is no exception
            // array? <- array is not null, array?[0]? <- array element is not null
            Class1[] array = null;
            int? j = array?[0]?.i;
            Console.WriteLine("1) the value of j is{0}",j);

            try
            {
                array = new Class1[]{};
                j = array?[0]?.i; // will through an error b/c index out of range
                Console.WriteLine("2) the value of j is {0}",j);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                // let just keep going
            }

            array = new Class1[]{null};
            j = array?[0]?.i; // will through an error b/c index out of range
            Console.WriteLine("3) the value of j is {0}",j);

            array = new Class1[]{ new Class1() {i= null } };
            j = array?[0]?.i;
            Console.WriteLine("5) the value of j is {0}",j);
            
            array = new Class1[]{ new Class1() {i=1 } };
            j = array?[0]?.i;
            Console.WriteLine("4) the value of j is {0}",j);

            array = new Class1[]{ new Class1() {i= null } };
            j = array?[0]?.i ?? 1;
            Console.WriteLine("6) the value of j is {0}",j);
        }
        public void UsingNullCheckInDelegate()
        {
            EventHandler eventHandler = null;
            if (eventHandler != null)
            {
                eventHandler.Invoke(this, new EventArgs());
            }
            // or we simply do this
            eventHandler?.Invoke(this, new EventArgs()); // four lines became one.

        }

        public void CheckEqualOfNullable()
        {
            int? i = null;
            int? j = null;
            if (i == j) // we didn't check if the sameness for null to
            {
                Console.WriteLine("0) i and j are the same"); 
            }       
            
            if (!i.HasValue && i == j) /// we don't want to match on nulls
            {
                Console.WriteLine("1) i and j are both null");
            }
            
            i = null;
            j = 1;
            if (i != j)
            {
                Console.WriteLine("2) i and j are not the same");
            }   
            
            i = null;
            j = 1;
            if (i != j)
            {
                Console.WriteLine("3) i and j are not the same");
            }
            
            i = 1;
            j = 1;
            if (i == j)
            {
                Console.WriteLine("4) i and j are the same");
            }
        }
        
        public NullableSkill()
        {
            //FullForm(); Nullable
            //ShortForm(); ?
            //ConditionalOperator(); object ? someobject (if not null) : someotherObject (if null)
            //NullCoelescingOperator(); object ?? value (if null)
            //NullPropertiesOfNullObjects(); object?.i ?? value(if null) 
            //NullInArray(); // null conditional operator ?.  or ?[
            //UsingNullCheckInDelegate(); ?.Invoke(...)
            //CheckEqualOfNullable();// object1 == object2 
        }

    }
}
