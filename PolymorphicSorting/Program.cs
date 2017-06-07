using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<object> {new SportsTeam("Newcastle", 4), new SportsTeam("Reading", 0), new SportsTeam("Cardiff",1)};
            var sortedTeams = SortFunctions.QuickSort(teams);
            Print(sortedTeams);

            var students = new List<object> { new Student("Charlotte"), new Student("Charlie") };
            var sortedStudents = SortFunctions.QuickSort(students);
            Print(sortedStudents);

            Console.ReadKey();
        }

        static void Print(List<object> list)
        {
            foreach (var obj in list)
            {
                Console.WriteLine(obj.ToString());
            }
            Console.WriteLine();
        }
   
    }
}
