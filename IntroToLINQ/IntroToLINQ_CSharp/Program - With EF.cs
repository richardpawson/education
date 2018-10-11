using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroToLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MyDbContext("MyDb");
            foreach(Student s in CreateStudents())
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var students = context.Students.Where(s => s.GCSEGrade > 7).OrderBy(s => s.FullName);

            foreach (var student in students)
            {
               Console.WriteLine(student.Summary());
            }
            Console.ReadKey();
        }

        static List<Student> CreateStudents() {
            var list = new List<Student>();
            list.Add(new Student("Olivia", 345, Sex.Female, 8));
            list.Add(new Student("Noah", 744,  Sex.Male, 6));
            list.Add(new Student("Emma", 219,  Sex.Female, 7));
            list.Add(new Student("Adi", 700,  Sex.Male, 9));
            list.Add(new Student("Charlotte", 345,  Sex.Female, 6));
            list.Add(new Student("Sebastian", 744,  Sex.Male, 5));
            list.Add(new Student("James", 219,  Sex.Male, 8));
            list.Add(new Student("Mia", 700,  Sex.Female, 9));
            return list;
        }

    }

  
}
