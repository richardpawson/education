using System;

namespace Objects101
{
    class StaticAndDynamicTyping
    {
        static void Main()
        {
             //C# is a 'statically-typed' language:
            //every variable or constant has a 'type' that is defined at compile time.

            //This may be specified explicitly:
            bool a = true;
            int b = 3;
            const double pi = 3.14159;
            char c = 'z';

            //(in C# the type comes before the name/identifier.
            //in some languages it comes after  e.g.  'a: bool = true')

            //In a statically typed language the type of that variable/constant never changes.
            //You can change the content to something of the same type:
            a = false;
            b = 45;
            //but never to another type
            //a = 3; //Uncomment this line to see that it does not compile
            c = b; //Uncomment this line to see that it does not compile
            //(comment out the lines above, in order to compile & run)

            //The type may also be 'inferred' rather than explicitly stated
            var e = 153;
            var f = pi;
            //but it is still static  -  you can't change the type subsequently:
            //e = false; //Uncomment this line to see that it does not compile
            //In c#, var is collquially referred to as an example of 'syntactic sugar':
            //its just a  convenient way to write the code, not a significant capability

            //both the arguments (parameters) of a function at its return type (if any)
            //are defined as static types
            var result = IsAtLeast10TimesLarger(b, e);
            //int otherResult = IsAtLeast10TimesLarger(b, e); //Uncomment this line to see that it does not compile
            //result = IsAtLeast10TimesLarger(b, f); //Uncomment this line to see that it does not compile

            //As of .NET 4.0, C# can also support 'dynamic typing':
            dynamic g = 3; //Initialised as an integer...
            g = true;  //..but OK to change to a bool during run-time!

            //This will compile OK...
            result = IsAtLeast10TimesLarger(b, g);
            //but it will give an error at run-time because the type of g is now boolean, not integer

            //if you used 'dynamic' everywhere in your C# code (instead of var or explicit types)
            //then this would be like programming in a 'dynamically typed language.
            //In theory, dynamic typing offers more flexibility and power, but the
            //main disadvantages are that:
            // - your code is harder to read/maintain, especially in complex programs
            // - fewer errors are picked up at compile time
            // - identifying the cause of an error may be harder
            // - slightly less performant

            //So most C# programmers use dynamic typing only rarely.
            //Conversely, many dynamically typed languages (e.g. Python, JavaScript)
            //Are gradually adding support for 'static typing'.
            //Best principle: when you have the choice, use static typing where yo
            //can i.e. where you know in advance what type it should be.

            //The relevance of static/dynamic typing becomes more significant
            //as we start looking at other types.

            //So far the types we have used are all 'value' types, which are:
            //- built into the language itself
            //- fixed in size (number of bytes per instance)
            //- the actual value (3, true, 'z') is associated directly with the identifier.
            //So when you copy a value variable into another...
            var h = b;
            //the actual value will exist in memory twice (but it is small).
            //And when you compare two variables of the same value type...
            if (h == b) { }
            //... then it is compares the two separate values.

            //Variables, and constants, may also hold 'reference types'.
            //These are not part of the language, but several come bundled
            //WITH the language, such as string and DateTime

            //Uncomment this:
            DateTime myDateOfBirth = new DateTime(1990, 11, 27);
            //You need to add 'using System;' at the top to compile it.

            //string and all arrays (e.g. int[]) are all examples of reference types
            int[] k = new int[] { 3, 67, 405, b };
            char[] l = new char[] {'h','e','l','l','0'};
            string hello = new string(l);
            string signOff = "goodbye";  //More 'syntactic sugar' -  much simpler than the line above
            // (string is a special case in several ways. So we'll use DateTime as a clearer example).

            //Common features of reference types:
            // - they are typically made up from multiple values (e.g. date, month & year, or array elements)
            // - individual instances will vary considerably in size
            // - the identifier does not hold the content directly, but
            // a refernce (memory pointer) to the content.

            //So when you copy a reference type ...
            DateTime myStartOfEducation = myDateOfBirth;
            // The content is NOT copied (duplicated), but the reference (memory pointer) is copied.
            // And when you compare two variables of the same reference type...
            if (myStartOfEducation == myDateOfBirth) { }
            // then it is just checking to see if both hold the same reference pointer.

            //Sometimes it is possible to extract component value types from the reference types:
            var k2 = k[2];
            int month = myDateOfBirth.Month;

            //but:
            //1. Only if that reference type has been deliberately designed to let you do so.
            //2. Just because a DateTime can give you a value for Month, does not mean
            //that it stores that value explicitly.  In fact DateTimes are stored as
            //a single number of 'ticks' since since 12:00:00 midnight, January 1, 0001
            //and everything else is calculated from that, as needed.

            //DateTime is in fact an object. And it demonstrates two key principles
            //of object-orientation:
            // 1. Objects have behaviour as well as data (state).
            // 2. Objects 'separate the interface from the implementation'.

            //The behaviour of DateTime may be hidden, as in the case of deriving
            // the month, or year from the ticks, or it may be 'explicit' in the
            //form of functions, such as:

            var myFirstBirthday = myDateOfBirth.AddMonths(12);
            
            //Functions like AddMonths, and properties such as DayOfWeek,
            //are said to be 'members' of the type DateTime.  In an IDE,
            //which compiles code continuously in the background, you can
            //view the members just by typing '.' after a variable.
            
            //(we tend to call the functions on an object its 'methods', but
            //this is not really an important distinction. Methods ARE functions.

            //They belong to the object -  you can't use them in isolation
            //from an object.  And, importantly, they have privileged access
            //to the internals of the object, hidden from the outside.

            //All this gets far more interesting when we start defining
            //our own objects.
            
               







        }
        static bool IsAtLeast10TimesLarger(int smaller, int larger)
        {
            return larger >= smaller * 10;
        }
    }
}
