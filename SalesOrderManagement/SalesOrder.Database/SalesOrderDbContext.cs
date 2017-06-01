
using SalesOrder.Model;
using System.Data.Entity;

namespace SalesOrder.Database
{
    public class SalesOrderDbContext : DbContext
    {
        public SalesOrderDbContext(string dbName, IDatabaseInitializer<SalesOrderDbContext> initializer) : base(dbName)
        {
            System.Data.Entity.Database.SetInitializer(initializer);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
