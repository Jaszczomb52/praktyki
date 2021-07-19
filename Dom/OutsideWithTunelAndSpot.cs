using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class OutsideWithTunelAndSpot:OutsideWithHidingSpot, IHasHole
    {
        public string HoleDescription { get; }
        public OutsideWithTunelAndSpot(string name, bool hot, string holeDescription,string HidingSpotDescription, Ellipse waypoint, HidingSpot HidingLocation) : base(name, hot,HidingSpotDescription, waypoint,HidingLocation)
        {
        }

        public override string Description
        {
            get
            {
                return base.Description + " Przy krzakach widzisz " + HoleDescription + ". To wejście do tunelu!";
            }
        }
    }
}
