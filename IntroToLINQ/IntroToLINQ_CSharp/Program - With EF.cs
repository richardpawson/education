using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IntroToLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MyDbContext("MyDb");
            foreach(Student s in Students())
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var students = context.Students.Where(s => s.PredictedGrade == "A").OrderBy(s => s.DateOfBirth);

            foreach (var student in students)
            {
               Console.WriteLine(student.Summary());
            }
            Console.ReadKey();
        }


        static List<Student> Students() {
            var list = new List<Student>();
            list.Add(new Student("Olivia", 345, new DateTime(2000,4,6),"C"));
            list.Add(new Student("Noah", 744, new DateTime(2001, 4, 6), "A"));
            list.Add(new Student("Emma", 219, new DateTime(2000, 1, 6), "A"));
            list.Add(new Student("Adi", 700, new DateTime(2000, 12, 7), "B"));
            list.Add(new Student("Charlotte", 345, new DateTime(2000, 5,16), "C"));
            list.Add(new Student("Sebastian", 744, new DateTime(2001, 4, 30), "A"));
            list.Add(new Student("James", 219, new DateTime(2000, 7, 6), "D"));
            list.Add(new Student("Mia", 700, new DateTime(2000, 11, 20), "A"));
            return list;
        }

    }

  
}
