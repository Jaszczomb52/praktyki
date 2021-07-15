using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUla
{
    
    class Bee
    {
        public const double HoneyPerMg = .25;
        public double WeightMg { get; private set; }
        
        public Bee(double weightMg)
        {
            WeightMg = weightMg;
        }

        virtual public double HoneyConsumptionRate()
        {
            return WeightMg * HoneyPerMg;
        }
    }
}
