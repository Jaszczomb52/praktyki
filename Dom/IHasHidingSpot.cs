using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    interface IHasHidingSpot
    {
        string HidingSpotDescription { get; }
        HidingSpot HidingLocation { get; }
    }
}
