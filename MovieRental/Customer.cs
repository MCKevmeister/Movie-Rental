/* 
Refactoring movie rental based on the example from Martin Fowler
Fowler, M., & Beck, K. (1999). Refactoring: Improving the design of existing code. Addison-Wesley
*/

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring
{
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals;

        public Customer(string name)
        {
            _name = name;
            _rentals = new List<Rental>();
        }

        public string Name { get => _name; set => _name = value; }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string Statement()
        {
            // using a string builder instead of type string for preformance benefits https://www.codeproject.com/articles/14936/stringbuilder-vs-string-fast-string-operations-wit
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Rental Record for {0}\n", Name);
            foreach (var rental in _rentals)// not using linq here as aggregate is slower than foreach https://stackoverflow.com/questions/217805/using-linq-to-concatenate-strings
            { 
                result.AppendFormat("\t {0} \t {1} \n", rental.Movie.Title, rental.getCharge());
            }
            //add footer lines
            result.AppendFormat("Amount owed is {0} \n", GetTotalAmount());
            result.AppendFormat("You earned {0} frequent renter points", GetTotalFrequentRenterPoints());
            return result.ToString();
        }
        public double GetTotalAmount() 
        {
            // Replace temps with query, replace foreach with Linq https://csharpsage.com/c-linq-foreach/
            return _rentals.Sum(rental => rental.getCharge());
        }
        public int GetTotalFrequentRenterPoints()
        {
            // Replace temps with query, replace foreach with Linq https://csharpsage.com/c-linq-foreach/
            return _rentals.Sum(rental => rental.getFrequentRenterPoints());
        }
    }
}
