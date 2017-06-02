using SalesOrder.Model;
using System.Data.Entity;

namespace SalesOrder.DataBase
{
    public class SalesOrderDbContext : DbContext
    {
        public SalesOrderDbContext(string dbName) : base(dbName)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SalesOrderDbContext>());
        }

        public SalesOrderDbContext(string dbName, IDatabaseInitializer<SalesOrderDbContext> initializer) : base(dbName)
        {
            Database.SetInitializer(initializer);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
