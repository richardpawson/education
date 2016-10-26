using System;

namespace MovieRental
{
	/// <summary>
	/// Rental represents a customer renting a movie.
	/// </summary>
	public class Rental
	{

    	public Rental(Movie movie, int daysRented)
		{
			Movie = movie;
			DaysRented = daysRented;
		}


        public virtual int DaysRented { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
