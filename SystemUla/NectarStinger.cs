using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUla
{
    class NectarStinger : Worker, INectarCollector, IStingPatrol
    {
        public NectarStinger(string[] jobs, double weightMg) : base(jobs, weightMg)
        {

        }
        public int AlertLevel { get; private set; }
        public int StingerLength { get; set; }
        public int Nectar { get; set; }
        public bool LookForEnemies()
        {
            return true;
        }
        public bool SharpenStinger(int Length)
        {
            return true;
        }
        public void FindFlowers()
        {

        }
        public void GatherNectar()
        {

        }
        public void ReturnToHive()
        {

        }
    }
}
