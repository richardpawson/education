using System;
using System.Collections;
using System.Collections.Generic;

namespace MovieRental
{
	/// <summary>
	/// Customer represents a customer of the store.
	/// </summary>
	public class Customer
	{
		public Customer(string name)
		{
			Name = name;
		}


        public virtual string Name { get; set; }

        #region Rentals (collection)
        private ICollection<Rental> _Rentals = new List<Rental>();

        public virtual ICollection<Rental> Rentals
        {
            get
            {
                return _Rentals;
            }
            set
            {
                _Rentals = value;
            }
        }
        #endregion


        public void AddRental(Rental arg)
		{
			Rentals.Add(arg);
		}

		public string GenerateStatement()
		{
			double totalAmount = 0;
			int frequentRenterPoints = 0;
			string result = "Rental record for " + Name + "\n";
			foreach(var rental in Rentals)
			{
				double thisAmount = 0;
				// Determine amounts for each line
				switch(rental.Movie.PriceCode)
				{
					case PriceCodes.Regular:
						thisAmount += 2;
						if (rental.DaysRented > 2)
						{
							thisAmount += (rental.DaysRented - 2) * 1.5;
						}
						break;

					case PriceCodes.NewRelease:
						thisAmount += rental.DaysRented *3;
						break;

					case PriceCodes.Childrens:
						thisAmount += 1.5;
						if (rental.DaysRented > 3)
						{
							thisAmount = (rental.DaysRented - 3) * 1.5;
						}
						break;
				}

				// Add frequent renter points
				frequentRenterPoints++;

				// Add bonus for a two-day new-release rental
				if ((rental.Movie.PriceCode == PriceCodes.NewRelease) && (rental.DaysRented > 1))
				{
					frequentRenterPoints ++;
				}

				// Show figures for this rental
				result += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString() + "\n";
				totalAmount += thisAmount;
			}

			// Add footer lines
			result += "Amount owed is " + totalAmount.ToString() + "\n";
			result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points.";
			return result;
		}
	}
}
