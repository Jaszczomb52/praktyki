using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public string DoorDescription { get; }
        public Location DoorLocation { set; get; }
        public RoomWithDoor(string name, string decoration, string doorDescription, Ellipse waypoint) : base(name, decoration, waypoint)
        {
            DoorDescription = doorDescription;
        }
    }
}
