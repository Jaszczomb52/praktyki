using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class OutsideWithTwoDoors: Outside, IHasTwoDoors
    {
        public string[] DoorDescription { get; }
        public Location[] DoorLocation { get; set; }
        public OutsideWithTwoDoors(string name, bool hot,string[] DoorDescription, Ellipse waypoint) : base(name, hot ,waypoint)
        {
            this.DoorDescription = DoorDescription;
        }

        public override string Description
        {
            get
            {

                string temp = "";
                for (int i = 1; i < DoorDescription.Length+1; i++)
                {
                    temp += "Patrzysz na "+ i +" drzwi. Widzisz " + DoorDescription[i-1] + ". ";
                }
                return base.Description + temp;
            }
        }

    }
}
