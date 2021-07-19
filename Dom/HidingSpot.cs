using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class HidingSpot : Location, IHidingSpot
    {
        public Location GetOut { get; set; }
        public HidingSpot(string name, Ellipse waypoint):base(name,waypoint)
        {
        }

        public override string Description
        {
            get
            {
                string description = "Ukrywasz się w " + Name + ".";
                return description;
            }
        }
    }
}
