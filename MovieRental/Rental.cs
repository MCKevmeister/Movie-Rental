/* 
Refactoring movie rental based on the example from Martin Fowler
Fowler, M., & Beck, K. (1999). Refactoring: Improving the design of existing code. Addison-Wesley
*/

namespace Refactoring
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int DaysRented { get => _daysRented; }
        public Movie Movie { get => _movie; }

        public double getCharge()
        {
            return Movie.GetCharge(DaysRented);
        }

        public int getFrequentRenterPoints()
        {
            return Movie.GetFrequenetRenterPoints(DaysRented);
        }
    }
 
}
