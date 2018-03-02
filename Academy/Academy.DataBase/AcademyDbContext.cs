
using System.Data.Entity;
using Academy.Model;

namespace Academy.DataBase
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext(string dbName, IDatabaseInitializer<AcademyDbContext> initializer) : base(dbName)
        {
            Database.SetInitializer(initializer);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<SubjectReport> SubjectReports { get; set; }
    }

}
