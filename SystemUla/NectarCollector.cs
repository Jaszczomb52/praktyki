using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUla
{
    class NectarCollector : Worker, INectarCollector
    {
        public int Nectar { get; set; }
        

        public NectarCollector(string[] jobs, double weightMg):base(jobs,weightMg)
        {

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
