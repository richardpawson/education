using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingByValAndByRef
{
    class Program
    {

        static void Main(string[] args)
        {
            //1. Passing a primitive (value) type by val and by ref 
            int a = 5;
            Console.WriteLine("addOneByVal:");
            Console.WriteLine("Before: " + a);
            //Adding one to param inside the function should have no impact on the variable a outside
            addOneByVal(a);
            Console.WriteLine("After: " + a);
            Console.WriteLine();

            a = 5;
            Console.WriteLine("addOneByRef:");
            Console.WriteLine("Before: " + a);
            //Adding one to param inside the function WILL impact the variable a outside
            addOneByRef(ref a);
            Console.WriteLine("After: " + a);
            Console.WriteLine();

            //2. Passing a reference type (an object) by val and by ref

            var fred = new Person("fred");
            Console.WriteLine("changeNameAndObjectByVal:");
            Console.WriteLine("Before: " + fred.name);
            //Changing the name property of the object Will impact the fred variable outside
            //But the second change of re-assigning fred to a new person inside the function
            //will not impact  
            changeNameAndObjectByVal(fred);
            Console.WriteLine("After: " + fred.name);
            Console.WriteLine();

             fred = new Person("fred");
            Console.WriteLine("changeNameAndObjectByRef:");
            Console.WriteLine("Before: " + fred.name);
            //The second changed of re-assigning fred to a new person inside the function
            //becomes visible outside: fred now refers to a new person object 
            changeNameAndObjectByRef(ref fred);
            Console.WriteLine("After: " + fred.name);
            Console.WriteLine();

            //3. Passing string (which is a reference type, but unusual because it is
            //an immutable type) by val and by ref.  So it behaves more like a primitive
            //value type even though it isn't
            var s = "abc";
            Console.WriteLine("addStarToStringByVal:");
            Console.WriteLine("Before: " + s);
            addStarToStringByVal(s);
            Console.WriteLine("After: " + s);
            Console.WriteLine();

            s = "abc";
            Console.WriteLine("addStarToStringByRef:");
            Console.WriteLine("Before: " + s);
            addStarToStringByRef(ref s);
            Console.WriteLine("After: " + s);
            Console.WriteLine();

            Console.ReadKey();
        }

        static void addOneByVal(int a)
        {
            a += 1;
        }

        static void addOneByRef(ref int a)
        {
            a += 1;
        }

        static void changeNameAndObjectByVal(Person a)
        {
            a.name = "Frederick";
            a = new Person("New Person");
        }

        static void changeNameAndObjectByRef(ref Person a)
        {
            a.name = "Frederick";
            a = new Person("New Person");
        }

        static void addStarToStringByVal(string a)
        {
            a += "*";
        }

        static void addStarToStringByRef(ref string a)
        {
            a += "*";
        }

    }

    class Person
    {
        public Person(string name)
        {
            this.name = name;
        }
        public string name { get; set; }

    }

    
}
