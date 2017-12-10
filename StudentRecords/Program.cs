using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentRecords
{
    class Program
    {
        static List<string> records = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Student Records");
            ReadInFile("Records1.csv");
            Console.WriteLine();
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("1 - List All Records");
                Console.WriteLine("2 - Find Student by Index");
                Console.WriteLine("3 - Update a Student's Grade");
                Console.WriteLine("4 - Write to file");
                Console.WriteLine("9 - Quit");
                Console.Write("Select an option: ");
                char menuChoice = Console.ReadLine().ToCharArray()[0];
                Console.WriteLine();
                switch (menuChoice)
                {
                    case '1':
                        ListAllRecords();
                        break;
                    case '2':
                        FindStudentByIndex();
                        break;
                    case '3':
                        UpdateGrade();
                        break;
                    case '4':
                        WriteToFile();
                        break;
                    case '9':
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice");
                        break;
                }
            }
        }

        static void ReadInFile(string fileName)
        {
            try
            {
                int number = ReadFileIntoRecordsList(fileName);
                Console.WriteLine("{0} Records read in", number);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File " + fileName + " not found.");
            }
        }

        static void WriteToFile()
        {
            Console.WriteLine("Enter file name to write to: ");
            string fileName = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach(var record in records )
                {
                    writer.WriteLine(record);
                }
                writer.Flush();
            }
        }

        static void UpdateGrade()
        {
            int index = FindStudentByIndex();
            Console.Write("Enter new grade:");
            string newGrade = Console.ReadLine().First().ToString();
            string record = records[index];
            records[index] = record.Substring(0, record.Length - 1) + newGrade;
            Console.WriteLine("Updated record: ");
            WriteRecordToConsole(records[index]);
        }

        static int FindStudentByIndex()
        {
                Console.Write("Enter Student Index (not the Student number):");
                try
                {
                    int index = Convert.ToInt32(Console.ReadLine());
                    WriteRecordToConsole(records[index]);
                return index;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Not a valid index");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a number");
                }
            return -1;
        }


        //Returns the number of records read in
        static int ReadFileIntoRecordsList(string fileName)
        {
            int i = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    records.Add(reader.ReadLine());
                    i++;
                }
            }
            return i;
        }

        static void WriteRecordToConsole(string record)
        {
            var formatted = record.Replace(",", "\t");
            Console.WriteLine(formatted);
        }

        static void ListAllRecords()
        {
            foreach (var record in records)
            {
                WriteRecordToConsole(record);
            }
        }
    }
}
