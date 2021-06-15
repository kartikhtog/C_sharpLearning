using System;
using System.Collections.Generic;
using System.Text;

namespace skills.BestPractices
{
    public class WritingMethods
    {
        public WritingMethods()
        {
            var methods = new Methods();

            /// what is this method doing... not great method... what are there boolean values
            methods.PlaceOrder(new Product(), 1, true, false);

            /// how many parametes are too many
            ///  some say 7 others say 4
            ///  also use object type

            // First start with order of parametes...put the parameters in order of importance
            // Second create doc for those pararmeters allows you hover the signature to know what to pass in

            // also the calling code explicit state what is being passed in
            methods.PlaceOrder(product: new Product(),
                                number: 1,
                                includeAddress: true,
                                sendCopy: false);
            // this is easier to read
            // not all arguements need to be named
            // all named arguements must follow positional arguments
            methods.PlaceOrder(new Product(), 1,
                                includeAddress: true,
                                sendCopy: false);
            /// maybe is cleaner... we can kind of what the first two are by intuition
            /// avoid unneccessary named arugments
            /// this approach still replies on the caller to add the named args

            /// Here is better approach

            methods.PlaceOrder(new Product(), 1, IncludeAddress.yes, SendCopy.no);
            // favor enum over constants

            // also use default parameteres
            // notice we can also skip over default parameters by using named parameters
            methods.PlaceOrder2(new Product(), 1, sendCopy: SendCopy.no);

            // lets look at ref and out
            // out has to declared but not initialed, ref has to initalized before all the method
            Product product;
            if (methods.PlaceOrder3(new Product(), 2, out product))
            {
                Console.WriteLine(product);
            }

            /// object are passed in my ref by default?
            var test = new Test();
            Console.WriteLine(test.i);
            DoSomethingToTest(test);
            Console.WriteLine(test.i);
            // yes but not primitive types or ummutale types unless ref keyword is used
         



        }
        public void DoSomethingToTest(Test test)
        {
            test.i = 2;
        }
    }

    public class Methods
    {
        public Product PlaceOrder(Product product, int number, bool includeAddress, bool sendCopy) { return new Product(); }
        public Product PlaceOrder(Product product, int number, IncludeAddress includeAddress, SendCopy sendCopy) { return new Product(); }
        public Product PlaceOrder2(Product product, int number, IncludeAddress includeAddress = IncludeAddress.yes, SendCopy sendCopy = SendCopy.no) { return new Product(); }
        
        public bool PlaceOrder3(Product product, int number, out Product product2) 
        { 
            product2 = new Product();  
            return true; 
        }
        // ref doesn't have to assign anything
        public bool PlaceOrder3(Product product, ref Product product2) 
        {
            return true; 
        }
    }
    public enum IncludeAddress{
        yes,
        no
    }
    public enum SendCopy{
        yes,
        no
    }

    public class Product { public override string ToString() { return "product object"; } }


    public class Test
    {
        public int i = 1;
    }


}
