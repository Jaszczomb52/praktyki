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
        public Bets(string name, int amount, int york)
        {
            this.name = name;
            this.amount = amount;
            this.york = york;
        }

        public bool Check(int number)
        {
            if (york == number)
                return true;
            else
                return false;
        }
    }
}
