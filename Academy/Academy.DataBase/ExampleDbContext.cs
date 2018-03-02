
using System.Data.Entity;
using Academy.Model;

namespace Academy.DataBase
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(string dbName, IDatabaseInitializer<ExampleDbContext> initializer) : base(dbName)
        {
            Database.SetInitializer(initializer);
        }

        public DbSet<Student> Students { get; set; }
    }

}
