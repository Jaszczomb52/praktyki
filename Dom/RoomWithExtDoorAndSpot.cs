using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class RoomWithExtDoorAndSpot: RoomWithHidingSpot, IHasHidingSpot, IHasExteriorDoor
    {
        public string DoorDescription { get; }
        public Location DoorLocation { set; get; }
        public RoomWithExtDoorAndSpot(string name, string decoration, string doorDescription, string HidingSpotDescription, Ellipse waypoint,HidingSpot spot) : base(name, decoration,HidingSpotDescription, waypoint,spot)
        {
            DoorDescription = doorDescription;
        }
    }
}
