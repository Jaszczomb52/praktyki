using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    class Bird
    {
        public string Name { get; set; }

        public Bird(string name)
        {
            Name = name;
        }

        public virtual void Fly()
        {
            Console.WriteLine(Name + " poszybował!");
        }

        public override string ToString()
        {
            return "Ptak " + Name;
        }
    }
}
