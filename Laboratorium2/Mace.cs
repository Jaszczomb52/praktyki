using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratorium2
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location, System.Windows.Controls.Image img) :base(game,location,img)
        {

        }

        public override string Name { get { return "Buława"; } }
        public override void Attack(Direction direction, Random random)
        {
            
        }
    }
}
