
using FilmRentals.Model;
using System.Data.Entity;

namespace FilmRentals.Data
{
    public class FilmRentalsDbContext : DbContext
    {
        public FilmRentalsDbContext(string dbName) : base(dbName)
        {
            Database.SetInitializer(new FilmRentalInitialiser());
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }

    public class FilmRentalInitialiser :
                      DropCreateDatabaseAlways<FilmRentalsDbContext>
    {
        protected override void Seed(FilmRentalsDbContext context)
        {
            FilmRentalDataFixture.CreateData(context);
        }
    }
}
