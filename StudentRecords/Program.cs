using System;
using System.IO;

namespace StudentRecords
{
    class Program
    {
        static string[] records = new string[5];

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Student Records");
            while (true)
            {
                Console.WriteLine("1 - Read File");
                Console.WriteLine("2 - Find Student by index No.");
                Console.Write("Select an option: ");
                char menuChoice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (menuChoice)
                {
                    case '1':
                        ReadInFile();
                        break;
                    case '2':
                        FindRecordByIndex();
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice");
                        break;
                }
            }
        }

        static void ReadInFile()
        {
            Console.Write("Enter FileName: ");
            string fileName = Console.ReadLine() + ".csv";
            try
            {
                ReadFileIntoRecordsArray(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File does not exist");
            }
        }

        static void FindRecordByIndex()
        {
            Console.Write("Enter Index No. :");
            int index = Convert.ToInt32(Console.ReadLine());
            try
            {
                WriteRecordToConsole(records[index]));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Not a valid index");
            }
        }

        static void ReadFileIntoRecordsArray(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    records[i] = reader.ReadLine();
                    i++;
                }
            }
        }

        static void WriteRecordToConsole(string record)
        {
            var formatted = record.Replace(",", "/t");
            Console.WriteLine(formatted);
        }
    }
}
