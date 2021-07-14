﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torty
{
    class Party
    {
        private const int foodPerPerson = 25;
        private int numberOfPeople = 0;
        private decimal drinksPerPerson = 0.00M;
        private decimal decorations = 0.00M;
        private decimal cost = 0.00M;
        

        public Party(int NumberOfPeople, bool Decorations, bool Health)
        {
            Refresh(NumberOfPeople, Decorations, Health);
        }

        public void Refresh(int NumberOfPeople, bool Decorations, bool Health)
        {
            numberOfPeople = NumberOfPeople;
            CalculateDecorations(Decorations);
            CalculateCostPerPerson(Health);
            HowMuch(Health);
        }

        private void CalculateDecorations(bool fancy)
        {
            if(fancy)
            {
                decorations = (numberOfPeople * 15.00M) + 50M;
            }
            else
            {
                decorations = (numberOfPeople * 7.50M) + 30M;
            }
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
            cost = decorations + ((drinksPerPerson + foodPerPerson) * numberOfPeople);
            if(health)
            {
                Math.Round(cost * 0.95M,2);
            }
        }

        public decimal GetThePrice()
        {
            return cost;
        }
    }
}
