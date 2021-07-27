using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboratorium2
{
    class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location):base(game,location,10)
        {

        }

        public override void Move(Random random)
        {
            
        }
    }
}
