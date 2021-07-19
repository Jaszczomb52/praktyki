using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class OutsideWithTunel: Outside, IHasHole
    {
        public string HoleDescription { get; }
        public Location[] TunelLocations { set; get; }
        public OutsideWithTunel(string name, bool hot, string holeDescription, Ellipse waypoint) : base(name, hot, waypoint)
        {
            HoleDescription = holeDescription;
        }

        public override string Description
        {
            get
            {
                return base.Description + " W krzakach widzisz " + HoleDescription + ". To wejście do tunelu!";
            }
        }
    }
}
