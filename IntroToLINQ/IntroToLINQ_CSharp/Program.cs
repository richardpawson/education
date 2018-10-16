using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = girlsNames.OrderBy(a => a.Contains("l"));
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.ReadKey();
        }

        static string[] girlsNames = { "Olivia", "Emma", "Ali", "Isabella", "Sophia", "Mia", "Charlotte", "Amelia", "Evelyn", "Abigail" };
        static ArrayList boys = new ArrayList { "Sebastian", "Noah", "Oliver", "James", "Adi", "Alexander", "Benjamin", "Zvi" };
        static int[] testScores = { 45, 87, 23, 66, 70, 52, 48, 32, 90 };


        static List<Student> CreateStudents() {
            var list = new List<Student>();
            list.Add(new Student("Olivia", 345, new DateTime(2000,4,6),'C'));
            list.Add(new Student("Noah", 744, new DateTime(2001, 4, 6), 'A'));
            list.Add(new Student("Emma", 219, new DateTime(2000, 1, 6), 'A'));
            list.Add(new Student("Adi", 700, new DateTime(2000, 12, 7), 'B'));
            list.Add(new Student("Charlotte", 345, new DateTime(2000, 5,16), 'C'));
            list.Add(new Student("Sebastian", 744, new DateTime(2001, 4, 30), 'A'));
            list.Add(new Student("James", 219, new DateTime(2000, 7, 6), 'D'));
            list.Add(new Student("Mia", 700, new DateTime(2000, 11, 20), 'A'));
            return list;
        }

    }

  
}
