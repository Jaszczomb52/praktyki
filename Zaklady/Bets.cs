using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaklady
{
    class Bets
    {
        public string name;
        public int amount;
        public int york;
        public Bets(string name, int amount, int york) // contructor adding data to the vars in the instance of this class
        {
            this.name = name;
            this.amount = amount;
            this.york = york;
        }

        public bool Check(int number) // method checking if this guy bets on this certain dog
        {
            if (york == number)
                return true;
            else
                return false;
        }
    }
}
