
using FilmRentals.Model;
using System.Data.Entity;

namespace FilmRentals.Data
{
    public class FilmRentalDbContext : DbContext
    {
        public FilmRentalDbContext(string dbName) : base(dbName)
        {
            Database.SetInitializer(new FilmRentalInitialiser());
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }

    public class FilmRentalInitialiser :
                      DropCreateDatabaseAlways<FilmRentalDbContext>
    {
        protected override void Seed(FilmRentalDbContext context)
        {
            FilmRentalDataFixture.CreateData(context);
        }
    }
}
