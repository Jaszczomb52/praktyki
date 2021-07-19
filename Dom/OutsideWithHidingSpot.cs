using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class OutsideWithHidingSpot : Outside, IHasHidingSpot
    {
        public string HidingSpotDescription { get; }
        public HidingSpot HidingLocation { get; }
        public OutsideWithHidingSpot(string name, bool hot, string hidingSpotDescription, Ellipse waypoint, HidingSpot HidingLocation) : base(name, hot, waypoint)
        {
            this.HidingSpotDescription = hidingSpotDescription;
            this.HidingLocation = HidingLocation;
        }
    }
}
