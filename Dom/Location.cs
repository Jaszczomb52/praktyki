﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    abstract class Location
    {
        public string Name { get; private set; }
        public Location[] Exits;


        public Location(string name)
        {
            Name = name;
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
