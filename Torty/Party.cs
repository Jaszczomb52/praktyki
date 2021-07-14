using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torty
{
    class Party : AnyParty
    {
        protected const int foodPerPerson = 25;
        private decimal drinksPerPerson = 0.00M;
        

        public Party(int NumberOfPeople, bool Decorations, bool Health):base(NumberOfPeople,Decorations)
        {
            Refresh(NumberOfPeople, Decorations, Health);
        }

        public void Refresh(int NumberOfPeople, bool Decorations, bool Health)
        {
            this.NumberOfPeople = NumberOfPeople;
            CalculateDecorations(Decorations);
            CalculateCostPerPerson(Health);
            HowMuch(Health);
        }

        private void CalculateCostPerPerson(bool health)
        {
            if(health)
            {
                drinksPerPerson = 5.00M;
            }
            else
            {
                drinksPerPerson = 20.00M;
            }
        }

        private void HowMuch(bool health)
        {
            Cost = Decorations + ((drinksPerPerson + foodPerPerson) * NumberOfPeople);
            if(health)
            {
                Cost *= .95M;
            }
        }
    }
}
