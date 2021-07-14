using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torty
{
    class AnyParty
    {
        protected int NumberOfPeople { get; set; }
        protected decimal Decorations { get; set; }
        protected decimal FoodPricePerPerson = 25.00M;
        protected decimal Cost { get; set; }
        public AnyParty(int NumberOfPeople, bool Decorations)
        {
            this.NumberOfPeople = NumberOfPeople;
            CalculateDecorations(Decorations);
        }
        protected void CalculateDecorations(bool fancy)
        {
            if (fancy)
            {
                Decorations = (NumberOfPeople * 15.00M) + 50M;
            }
            else
            {
                Decorations = (NumberOfPeople * 7.50M) + 30M;
            }
        }
        public decimal GetThePrice()
        {
            return Cost;
        }
    }
}
