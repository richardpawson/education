namespace StaticAndDynamicTyping
{
    class Code
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

            //Q1: Why does this line not compile? 
            a = 3;
            // Answer here:
            //Then comment out the line above to continue

            //Q2:Why does this line not compile? 
            c = b;
            // Answer here: 
            //Then comment out the line above to continue

            //The type may also be 'inferred' rather than explicitly stated
            var e = 153;
            var f = pi;
            //but it is still static.

            // Q3: Why does this not compile? 
            e = false;
            // Answer here: 
            //Then comment out the line above to continue

            //In c#, 'var' is collquially referred to as an example of 'syntactic sugar':
            //It is just a convenient way to write the code, not a significant capability

            //both the arguments (parameters) of a function at its return type (if any) are defined as static types.

            //Q4: What are the types of the paramaters and the return type for the function called below?
            var result = IsAtLeast10TimesLarger(b, e);
            //Answer here: 


            //Q5: Why does this not compile?
            int otherResult = IsAtLeast10TimesLarger(b, e);
            //Answer here: 
            //Then comment out the line above to continue

            //Q6: Why does this line not compile?
            result = IsAtLeast10TimesLarger(b, f);
            //Answer here: 
            //Then comment out the line above to continue

            //As of .NET 4.0, C# can also support 'dynamic typing':
            dynamic g = 3; //Initialised as an integer...
            g = true;  //..but OK to change to a bool during run-time!

            //Q7: The line below compiles, but you will get an error at run-time, why?
            result = IsAtLeast10TimesLarger(b, g);
            //Answer here: 
            //If you are unable to predict why there will be a run-time error, make the code compile and run it

            //if you used 'dynamic' everywhere in your C# code (instead of var or explicit types)
            //then this would be like programming in a 'dynamically typed' language (such as Python or JavaScript).
            
            //In theory, dynamic typing offers more flexibility and power, but the
            //main disadvantages are that:
            // - your code is harder to read/maintain, especially in complex programs
            // - fewer errors are picked up at compile time
            // - identifying the cause of an error may be harder
            // - slightly less performant

            //So most C# programmers use dynamic typing only rarely.
            //Conversely, many dynamically typed languages (e.g. Python, JavaScript)
            //are gradually adding support for 'static typing'.
            //Best principle: when you have the choice, use static typing where you
            //can i.e. where you know in advance what type it should be.

            //The relevance of static/dynamic typing becomes more significant
            //in object-oriented programming, because with static typing the compiler knows
            //what are the capabilities of each object at compile time; in dynamic typing
            //the actual capabilities of a given object instance are not known until run-time.

        }
        static bool IsAtLeast10TimesLarger(int smaller, int larger)
        {
            return larger >= smaller * 10;
        }
    }
}
