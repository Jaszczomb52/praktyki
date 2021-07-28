using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;

namespace Laboratorium2
{
    abstract class Mover
    {
        private const int MoveInterval = 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;
        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }

        public bool Nearby(Point locationToCheck, int distance)
        {
            if (Math.Abs(location.X - locationToCheck.X) < distance &&
                Math.Abs(location.Y - locationToCheck.Y) < distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
