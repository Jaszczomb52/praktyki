using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Serializacja
{
    [Serializable]
    class Guy
    {
        public int Money { get; private set; }
        public string Name { get; private set; }

        public Guy(int money, string name)
        {
            Money = money;
            Name = name;
        }

        private void AddMoney(int amount)
        {
            Money += amount;
        }

        private void RemoveMoney(int amount)
        {
            Money -= amount;
        }

        public void SendMoney(Guy reciver, int amount)
        {
            if(Money-amount > 0)
            {
                reciver.AddMoney(amount);
                RemoveMoney(amount);
            }
            else
            {
                MessageBox.Show("Za mało środków");
            }
            
        }

        public override string ToString()
        {
            return Name + " ma " + Money.ToString() + " zł";
        }
    }
}
