using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboratorium2
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location):base(game,location,8)
        {

        }

        public override void Move(Random random)
        {
            
        }
    }
}
