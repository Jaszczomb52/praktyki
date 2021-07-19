using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class RoomWithTunelAndSpot : RoomWithHidingSpot, IHasHole
    {
        public string HoleDescription { get; }
        public RoomWithTunelAndSpot(string name, string decoration, string HoleDescription,string HidingSpotDescription, Ellipse waypoint, HidingSpot HidingLocation) : base(name, decoration,HidingSpotDescription, waypoint,HidingLocation)
        {
            this.HidingLocation = HidingLocation;
            this.HoleDescription = HoleDescription;
        }

        public override string Description
        {
            get
            {
                return base.Description + " W rogu widzisz " + HoleDescription + ". To wejście do tunelu!";
            }
        }
    }
}
