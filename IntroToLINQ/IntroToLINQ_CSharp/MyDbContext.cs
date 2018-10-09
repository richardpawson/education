using System.Data.Entity;

namespace IntroToLINQ
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(string name) : base(name)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
