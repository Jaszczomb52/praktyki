using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium2
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location):base(game, location)
        {
            
        }

        public override string Name { get { return "Miecz"; } }
        public override void Attack(Direction direction, Random random)
        {
            
        }
    }
}
