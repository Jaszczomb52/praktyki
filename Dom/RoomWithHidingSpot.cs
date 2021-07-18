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
        public string hidingSpotDescription { get; }
        public RoomWithHidingSpot(string name, string decoration, string hidingSpotDescription, Ellipse waypoint) : base(name, decoration, waypoint)
        {
            this.hidingSpotDescription = hidingSpotDescription;
        }
    }
}
