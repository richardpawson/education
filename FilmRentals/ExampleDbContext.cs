
using System.Data.Entity;

namespace FilmRentals
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
            CreateMember(context, "Toby Lawrance", "26 The Street, Silverstone");
            CreateMember(context, "Olly Clarke", "26 The Street, Oxford");
            var pg = CreateRating(context, "PG", 13);
            var r = CreateRating(context, "R", 17);
            CreateFilm(context, "Casino Royale", 2.50, pg);
            CreateFilm(context, "Star Trek: Beyond", 5.00, pg);



        }

        private Member CreateMember(FilmRentalDbContext context, string name, string address)
        {
            return context.Members.Add(new Member
            {
                Name = name,
                Address = address
            });
        }

        private Rating CreateRating(FilmRentalDbContext context, string description, int age)
        {
            return context.Ratings.Add(new Rating
            {
                Description = description,
                Age = age
            });
        }

        private Film CreateFilm(FilmRentalDbContext context, string title, double cost, Rating rating)
        {
            return context.Films.Add(new Film
            {
                Title = title,
                Cost = (decimal) cost,
                Rating = rating
            });
        }
    }

}
