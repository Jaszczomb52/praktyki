using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class Room : Location
    {
        private string decoration;
        public Room(string name, string decoration, Ellipse waypoint):base(name,waypoint)
        {
            this.decoration = decoration;
        }

        public override string Description
        {
            get
            {
                return base.Description + " Widzisz tutaj " + decoration + ".";
            }
        }
    }
}
