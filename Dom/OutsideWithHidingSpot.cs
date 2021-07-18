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
        public string hidingSpotDescription { get; }
        public OutsideWithHidingSpot(string name, bool hot, string hidingSpotDescription, Ellipse waypoint) : base(name, hot, waypoint)
        {
            this.hidingSpotDescription = hidingSpotDescription;
        }
    }
}
