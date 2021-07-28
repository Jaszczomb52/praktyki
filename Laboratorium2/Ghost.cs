using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;

namespace Laboratorium2
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location,System.Windows.Controls.Image img):base(game,location,8,img)
        {

        }

        public override void Move(Random random)
        {
            Direction direction = (Direction)random.Next(0,4);
            if (direction == Direction.Right && Canvas.GetLeft(img) < 575)
                Canvas.SetLeft(img, Canvas.GetLeft(img) + 10);
            else if (direction == Direction.Down && Canvas.GetTop(img) < 175)
                Canvas.SetTop(img, Canvas.GetTop(img) + 10);
            else if (direction == Direction.Left && Canvas.GetLeft(img) > 0)
                Canvas.SetLeft(img, Canvas.GetLeft(img) - 10);
            else if (direction == Direction.Up && Canvas.GetTop(img) > 0)
                Canvas.SetTop(img, Canvas.GetTop(img) - 10);
        }
    }
}
