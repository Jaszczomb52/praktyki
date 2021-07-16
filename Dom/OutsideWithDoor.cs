using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        public string DoorDescription { get; private set; }
        public Location DoorLocation { get; set; }
        public OutsideWithDoor(string name, bool hot, string doorDescription, Ellipse waypoint):base(name,hot,waypoint)
        {
            DoorDescription = doorDescription;
        }
        
        public override string Description
        {
            get
            {
                return base.Description + " Widzisz teraz " + DoorDescription + ".";
            }
        }
    }
}
