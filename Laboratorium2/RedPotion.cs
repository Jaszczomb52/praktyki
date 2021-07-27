﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboratorium2
{
    class RedPotion : Weapon, IPotion
    {
        public override string Name { get; }
        public bool Used { get; private set; }
        public RedPotion(Game game, Point location) : base(game, location)
        {
            Name = "Czerwona mikstura";
            Used = false;
        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(10, random);
            Used = true;
        }
    }
}
