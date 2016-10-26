
using NakedObjects;
using System.Collections.Generic;
using System.ComponentModel;

namespace FilmRentals.Model
{ 
    public class Member
    {
         [Disabled, MemberOrder(0), DisplayName("Membership Number")]
        public virtual int MemberId { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        [MemberOrder(1)] //Determines the order in which (visible) properties are displayed on the UI
        public virtual string Name { get; set; }

        [MemberOrder(2)]
        public virtual string Address { get; set; }

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
            foreach (var rental in Rentals)
            {
                double thisAmount = 0;
                // Determine amounts for each line
                switch (rental.Film.PriceCode)
                {
                    case PriceCodes.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                        {
                            thisAmount += (rental.DaysRented - 2) * 1.5;
                        }
                        break;

                    case PriceCodes.NewRelease:
                        thisAmount += rental.DaysRented * 3;
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
                if ((rental.Film.PriceCode == PriceCodes.NewRelease) && (rental.DaysRented > 1))
                {
                    frequentRenterPoints++;
                }

                // Show figures for this rental
                result += "\t" + rental.Film.Title + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            // Add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points.";
            return result;
        }
    }

}
