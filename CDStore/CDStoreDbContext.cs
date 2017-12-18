using System.Data.Entity;

namespace CDStore
{
    public class CDStoreDbContext : DbContext
    {
        public CDStoreDbContext() : base("myConnectionString")
        {
            Database.SetInitializer(
                new CustomInitializer());
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<CD> CDs { get; set; }
        public DbSet<RecordCompany> RecordCompanies { get; set; }
    }
}

