
using SalesOrder.Database;
using SalesOrder.Model;
using System;


namespace SalesOrder.SeedData
{
    public class SalesOrderDbInitilializer
    {
        private static SalesOrderDbContext context;
        public static void Seed(SalesOrderDbContext dbContext)
        {
            context = dbContext;
            var ad1 = AddNewAddress("The Cottage", "Lymeswold", "GL24 1XQ");
            var ad2 = AddNewAddress("13 Elm Street", "Woking", "GU17 9DD");

            var aa = AddNewCustomer("Algie Algol", ad1, ad2);
            var ff = AddNewCustomer("Forrest Fortran");
            var jj = AddNewCustomer("James Java");
            var ss = AddNewCustomer("Smilla Simula");

            var apple = AddNewProduct("Apple MacBook", 1595.00m);
            var dell = AddNewProduct("Dell Inspiron", 1250.50m);
            var yoga = AddNewProduct("Lenovo Yoga", 1370.95m);
        }

        private static Address AddNewAddress(string line1, string line2, string postCode)
        {
            var addr = new Address { Line1 = line1, Line2 = line2, PostCode = postCode };
            context.Addresses.Add(addr);
            context.SaveChanges();
            return addr;
        }

        private static Customer AddNewCustomer(string name, params Address[] addresses)
        {
            var cus = new Customer() { Name = name };
            context.Customers.Add(cus);
            cus.Addresses.AddRange(addresses);
            context.SaveChanges();
            return cus;
        }

        private static Product AddNewProduct(string name, decimal price)
        {
            var prod = new Product { Name = name, Price = price };
            context.Products.Add(prod);
            context.SaveChanges();
            return prod;
        }

        private static Order AddNewOrder(Customer cus, DateTime date, Address shipping, Address billing)
        {
            var ord = new Order { Customer = cus, OrderDate = date, ShippingAddress = shipping, BillingAddress = billing };
            context.Orders.Add(ord);
            context.SaveChanges();
            return ord;
        }

        private static OrderLine AddNewOrderLine(Order order, Product product, int quantity)
        {
            var line = new OrderLine() { Product = product, Quantity = quantity };
            context.OrderLines.Add(line);
            context.SaveChanges();
            return line;
        }

    }
}
