using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(47, "Alex", "Marsh", DateTime.par);
            //Notice that DateTime is in fact an object, and we are calling 
            //its own constructor, in-line
            s1.Grade = 'B';

            Console.WriteLine(s1.FirstName);
            Console.WriteLine(s2.FirstName);
        }
    }
}
