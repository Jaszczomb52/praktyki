using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class RoomWithTunel : Room , IHasHole
    {
        public string HoleDescription { get; }
        public Location[] TunelLocations { set; get; }
        public RoomWithTunel(string name, string decoration, string holeDescription, Ellipse waypoint) : base(name, decoration, waypoint)
        {
            HoleDescription = holeDescription;
        }
    }
}
