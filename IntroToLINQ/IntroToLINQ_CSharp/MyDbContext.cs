using System.Data.Entity;

namespace IntroToLINQ
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(string name) : base(name)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbContext>());
        }
        public DbSet<Student> Students { get; set; }
    }
}
