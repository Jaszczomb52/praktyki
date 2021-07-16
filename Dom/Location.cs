using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    abstract class Location
    {
        public string Name { get; private set; }
        public Ellipse waypoint { get; private set; }
        public Location[] Exits;
        public Location[] Tunels;


        public Location(string name, Ellipse waypoint)
        {
            Name = name;
            this.waypoint = waypoint;
        }

        public virtual string Description
        {
            get
            {
                string description = "Stoisz w: " + Name + ". Widzisz wyjscia do następujących miejsc: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += " " + Exits[i].Name;
                    if(i != Exits.Length - 1)
                    {
                        description += ", ";
                    }
                }
                description += ".";
                return description;
            }
        }
    }
}
