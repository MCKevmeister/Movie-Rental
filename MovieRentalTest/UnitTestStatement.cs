using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;
using System;

namespace MovieRentalTest
{
    [TestClass]
    public class UnitTestStatement
    {
        private const string Expected = "Rental Record for Customer A\n\tRaiders of the Lost Ark\t9\nAmount owed is 9\nYou earned 2 frequent renter points";
        private const double ExpectedCost = 9;
        [TestMethod]
        public void FirstTest()
        {
            Movie movie = new Movie("Raiders of the Lost Ark", Movie.NEWRELEASE);
            Rental rental = new Rental(movie, 3);
            Customer customer = new Customer("Customer A");
            customer.AddRental(rental);

            string statement = customer.Statement();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Cost()
        {
            Movie movie = new Movie("First Man", Movie.NEWRELEASE);
            Rental rental = new Rental(movie, 3);
            Customer customer = new Customer("Customer A");
            customer.AddRental(rental);

            var cost = movie.GetCharge(2);

            //string statement = customer.Statement();

            Assert.AreEqual(ExpectedCost, cost);
        }
    }
}
