using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUla
{
    class Patrol : Worker, IStingPatrol
    {
        public int AlertLevel { get; private set; }
        public int StingerLength { get; set; }

        public Patrol(string[] jobs, double weightMg):base(jobs,weightMg)
        {
            
        }

        public bool SharpenStinger(int Length)
        {
            return true;
        }
        
        public bool LookForEnemies()
        {
            return true;
        }

        public void Sting(string Enemy)
        {

        }
    }
}
