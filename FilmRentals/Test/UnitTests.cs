using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmRentals;
using FilmRentals.Model;
using FilmRentals.Data;

namespace FilmRentals.Test
{
    /// <summary>
    /// Unit tests for FilmRental project.
    /// </summary>
    [TestClass]
    public class UnitTests
    {
        /* Fields */

        // Films
        Film cinderella;
        Film starWars;
        Film gladiator;

        // Rentals
        Rental rental1;
        Rental rental2;
        Rental rental3;

        // Members
        Member mickeyMouse;
        Member donaldDuck;
        Member minnieMouse;

        /* Methods */

        [TestInitialize]
        public void Init()
        {

            //Create ratings
            var u = FilmRentalDataFixture.CreateRating(null, "U", 1);
            var pg = FilmRentalDataFixture.CreateRating(null, "PG", 13);
            var r = FilmRentalDataFixture.CreateRating(null, "R", 17);
            // Create Films
            cinderella = FilmRentalDataFixture.CreateFilm(null, "Cinderella", PriceCodes.Childrens, u);
            starWars = FilmRentalDataFixture.CreateFilm(null, "Star Wars", PriceCodes.Regular, pg);
            gladiator = FilmRentalDataFixture.CreateFilm(null, "Gladiator", PriceCodes.NewRelease, r);
            // Create Members
            mickeyMouse = FilmRentalDataFixture.CreateMember(null, "Mickey Mouse", "");
            donaldDuck = FilmRentalDataFixture.CreateMember(null, "Donald Duck", "");
            minnieMouse = FilmRentalDataFixture.CreateMember(null, "Minnie Mouse", "");
            // Create rentals
            rental1 = FilmRentalDataFixture.CreateRental(null, mickeyMouse, cinderella, 5);
            rental2 = FilmRentalDataFixture.CreateRental(null, mickeyMouse, starWars, 5);
            rental3 = FilmRentalDataFixture.CreateRental(null, mickeyMouse, gladiator, 5);
        }

        [TestMethod]
        public void TestMember()
        {
            // Test Name property
            Assert.AreEqual("Mickey Mouse", mickeyMouse.Name);
            Assert.AreEqual("Donald Duck", donaldDuck.Name);
            Assert.AreEqual("Minnie Mouse", minnieMouse.Name);
            // Test the Statement() method
            string theResult = mickeyMouse.GenerateStatement();

            // Parse the result
            char[] delimiters = "\n\t".ToCharArray();
            string[] results = theResult.Split(delimiters);

            /* The results[] array will have the following elements:
             *		[0] = junk
             *		[1] = junk
             *		[2] = title #1
             *		[3] = price #1
             *		[4] = junk
             *		[5] = title #2
             *		[6] = price #2
             *		[7] = junk
             *		[8] = title #3
             *		[9] = price #3
             *		[10] = "Amount owed is x"
             *		[11] = "You earned x frequent renter points."
             * We will test the title and price elements, and the total 
             * and frequent renter points items. If these tests pass, then 
             * we know that AddRentals() is adding rentals to a Member 
             * object properly, and that the Statement() method is
             * generating a statement in the expected format. */

            // Test the title and price items
            Assert.AreEqual("Cinderella", results[2]);
            Assert.AreEqual(3, Convert.ToDouble(results[3]));
            Assert.AreEqual("Star Wars", results[5]);
            Assert.AreEqual(6.5, Convert.ToDouble(results[6]));
            Assert.AreEqual("Gladiator", results[8]);
            Assert.AreEqual(15, Convert.ToDouble(results[9]));
        }
    }
}