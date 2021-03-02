/* 
Refactoring movie rental based on the example from Martin Fowler
Fowler, M., & Beck, K. (1999). Refactoring: Improving the design of existing code. Addison-Wesley
*/
using System;

namespace Refactoring
{
    public class Movie
    {
        public enum MovieType // replace consts with enum
        {
            Regular,
            NewRelease,
            Childrens
        }
        private string _title;
        private Price _price;

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }
        public int PriceCode
        {
            get { return _price.GetPriceCode(); }
            set
            {
                switch (value)
                {
                    case 0:
                        _price = new RegularPrice();
                        break;
                    case 1:
                        _price = new NewReleasePrice();
                        break;
                    case 2:
                        _price = new ChildrensPrice();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("value", "Incorrect Price Code");
                }
            }
        }
        public string Title { get => _title; set => _title = value; }

        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
        }
        public int GetFrequenetRenterPoints(int daysRented)
        {
            return _price.GetFrequentRenterPoints(daysRented);
        }
    }
}
