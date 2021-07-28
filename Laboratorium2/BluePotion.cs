using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratorium2
{
    class BluePotion : Weapon, IPotion
    {
        public override string Name { get; }
        public bool Used { get; private set; }
        public BluePotion(Game game, Point location):base(game,location)
        {
            Name = "Niebieska mikstura";
            Used = false;
        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(5, random);
            Used = true;
        }
    }
}
