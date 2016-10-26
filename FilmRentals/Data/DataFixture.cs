using FilmRentals.Model;

namespace FilmRentals.Data
{

    public static class FilmRentalDataFixture
    {

        public static void CreateData(FilmRentalDbContext dbContext)
        {

            CreateMember(dbContext, "Toby Lawrance", "26 The Street, Silverstone");
            CreateMember(dbContext, "Olly Clarke", "26 The Street, Oxford");
            var u = CreateRating(dbContext, "U", 1);
            var pg = CreateRating(dbContext, "PG", 13);
            var r = CreateRating(dbContext, "R", 17);
            CreateFilm(dbContext, "Casino Royale", PriceCodes.NewRelease, pg);
            CreateFilm(dbContext, "Star Trek: Beyond", PriceCodes.Regular, pg);
            CreateFilm(dbContext, "Mary Poppins", PriceCodes.Childrens, u);
        }

        public static Member CreateMember(FilmRentalDbContext context, string name, string address)
        {
            var member = new Member
            {
                Name = name,
                Address = address
            };
            if (context != null)
            {
                context.Members.Add(member);
            }
            return member;
        }

        public static Rating CreateRating(FilmRentalDbContext context, string description, int age)
        {
            var rating = new Rating
            {
                Description = description,
                Age = age
            };
            if (context != null)
            {
                context.Ratings.Add(rating);
            }
            return rating;
        }
        public static Film CreateFilm(FilmRentalDbContext context, string title, PriceCodes priceCode, Rating rating)
        {
            var film = new Film { Title = title, PriceCode = priceCode, Rating = rating };
            if (context != null)
            {
                context.Films.Add(film);
            }
            return film;
        }

        public static Rental CreateRental(FilmRentalDbContext context, Member member, Film film, int daysRented)
        {
            var rental = new Rental { Film = film, Member = member, DaysRented = daysRented };
            if (context != null)
            {
                context.Rentals.Add(rental);
            }
            member.Rentals.Add(rental);
            return rental;
        }

    }
}
