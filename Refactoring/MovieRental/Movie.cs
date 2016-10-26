using System;


namespace MovieRental
{
	/// <summary>
	/// Price codes
	/// </summary>
	public enum PriceCodes
	{
		Regular,
		NewRelease,
		Childrens
	}
	/// <summary>
	/// Movie is just a simple data class.
	/// </summary>
	public class Movie
	{
		/* Constructor */

		public Movie(string title, PriceCodes priceCode)
		{
			Title = title;
			PriceCode = priceCode;
		}

		/* Properties */

		public virtual PriceCodes PriceCode { get; set; }

		public virtual string Title { get; set; }
	}
}
