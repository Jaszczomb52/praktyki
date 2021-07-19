using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class RoomWithHidingSpot : Room , IHasHidingSpot
    {
        public string HidingSpotDescription { get; }

        public HidingSpot HidingLocation { get; set; }
        public RoomWithHidingSpot(string name, string decoration, string hidingSpotDescription, Ellipse waypoint, HidingSpot HidingLocation) : base(name, decoration, waypoint)
        {
            this.HidingSpotDescription = hidingSpotDescription;
            this.HidingLocation = HidingLocation;

        }
    }
}
