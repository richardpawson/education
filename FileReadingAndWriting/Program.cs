using System;
using System.IO;

namespace FileReadingAndWriting
{
    class Program
    {
        static void Main()
        {
            const string path = @"C:\Users\rpaws\Documents\visual studio 2015\Projects\FileReadingAndWriting\FileReadingAndWriting\";
            decimal[] columnTotals = null;
            decimal grandTotal = 0;
            int columnCount = 0;
            StreamReader reader = new StreamReader(path+"inputFile.txt");
            StreamWriter writer = new StreamWriter(path+"outputFile.txt");
            int row = 0;
            while (!reader.EndOfStream)
            {
                string inputLine = reader.ReadLine();
                string[] cells = inputLine.Split(',');
                if (columnCount == 0) //i.e. only  on first line
                {
                    columnCount = cells.Length;
                    columnTotals = new Decimal[columnCount+ 1]; //extra 1 for grand total
                }
                decimal lineTotal = 0;
                for (int col = 0; col < cells.Length; col++)
                {
                    decimal value = Convert.ToDecimal(cells[col]);
                    lineTotal += value;
                    columnTotals[col] += value;
                }
                string outputLine = inputLine + "," + lineTotal;
                writer.WriteLine(outputLine);
                grandTotal += lineTotal;
                row++;
            }
            for (int i = 0; i < columnCount; i++)
            {
                writer.Write(columnTotals[i] + ",");
            }
            writer.WriteLine(grandTotal);
            writer.Flush();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
