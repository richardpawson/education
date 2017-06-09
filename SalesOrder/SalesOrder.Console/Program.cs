using SalesOrder.DataBase;
using SalesOrder.Model;
using System;
using System.Linq;
using System.Data.Entity;

namespace ConsoleApplication
{
    class Program
    {
        private static SalesOrderDbContext context;

        static void Main(string[] args)
        {
            context = new SalesOrderDbContext("SalesOrders",new DropCreateDatabaseAlways<SalesOrderDbContext>());
            context.Customers.Add(new Customer() { Name = "Alison Algol" });
            context.Customers.Add(new Customer() { Name = "Forrest Fortran" });
            context.Customers.Add(new Customer() { Name = "James Java" });
            context.Customers.Add(new Customer() { Name = "Smilla Simula" });
            context.SaveChanges();

            while (true) {
                Console.WriteLine("Enter match string");
                var match = Console.ReadLine();
                var results = context.Customers.Where(c => c.Name.Contains(match)).ToList();
                foreach (var c in results)
                {
                    Console.WriteLine(c.Name);
                }
            }
        }
    }
}
