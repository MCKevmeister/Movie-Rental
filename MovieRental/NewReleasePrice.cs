using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return 1;
        }
        public override double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }
        public override int GetFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }
}
