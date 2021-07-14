using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torty
{

    class BDParty : AnyParty
    {
        private const int costOfFood = 25;
        private string CakeText { get; set; }
        private int CakeSize { get; set; }

        public BDParty(int NumberOfPeople, bool Decorations, string CakeText, int CakeSize):base(NumberOfPeople, Decorations)
        {
            Refresh(NumberOfPeople,Decorations,CakeText,CakeSize);
        }

        public void Refresh(int NumberOfPeople, bool Decorations, string CakeText, int CakeSize)
        {
            this.NumberOfPeople = NumberOfPeople;
            CalculateDecorations(Decorations);
            this.CakeText = CakeText;
            this.CakeSize = CakeSize;
            HowMuch();
        }

        private void HowMuch()
        {
            Cost = (NumberOfPeople * costOfFood) + Decorations;
            if(NumberOfPeople <= 4)
            {
                CakeSize = 20;
                Cost += CakeCalculate();
            }
            else
            {
                CakeSize = 40;
                Cost += CakeCalculate();
            }
        }

        private decimal CakeCalculate()
        {
            if(CakeSize == 20)
            {
                return 40.00M + (CakeText.Length * .25M);
            }
            else
            {
                return 75.00M + (CakeText.Length * .25M);
            }
        }
        public static int CakeTextCheck(int people)
        {
            if (people <= 4)
            {
                return 16;
            }
            else
            {
                return 40;
            }
        }

        public int ReturnCakeSize()
        {
            return CakeSize;
        }
    }
}
