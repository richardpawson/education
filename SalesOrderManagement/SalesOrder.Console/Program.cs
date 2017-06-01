using SalesOrder.Database;
using SalesOrder.SeedData;
using System;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SalesOrderDbContext("SalesOrders");
            SalesOrderDbInitilializer.Seed(context);
            var a1 = context.Customers.FirstOrDefault();

            Console.WriteLine(a1.Name);
            Console.ReadKey();
        }
    }
}
