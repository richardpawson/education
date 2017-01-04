using System;
using System.IO;

namespace FileReadingAndWriting
{
    class Program
    {
        static void Main()
        {
            using (StreamWriter writer = new StreamWriter("outputFile.txt"))
            {
                decimal[] columnTotals = null;
                decimal grandTotal = 0;
                int columnCount = 0;
                using (StreamReader reader = new StreamReader("inputFile.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string inputLine = reader.ReadLine();
                        string[] values = inputLine.Split(',');
                        if (columnCount == 0) //i.e. only  on first line
                        {
                            columnCount = values.Length;
                            columnTotals = new Decimal[columnCount + 1]; //extra 1 for grand total
                        }
                        decimal lineTotal = 0;
                        for (int col = 0; col < values.Length; col++)
                        {
                            decimal value = Convert.ToDecimal(values[col]);
                            lineTotal += value;
                            columnTotals[col] += value;
                        }
                        string outputLine = inputLine + "," + lineTotal;
                        writer.WriteLine(outputLine);
                        grandTotal += lineTotal;
                    }
                }
                for (int i = 0; i < columnCount; i++)
                {
                    writer.Write(columnTotals[i] + ",");
                }
                writer.WriteLine(grandTotal);
                writer.Flush();
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
