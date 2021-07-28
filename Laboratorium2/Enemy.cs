using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing;

namespace Laboratorium2
{
    abstract class Enemy : Mover
    {
        private const int NearPlayerDistance = 25;
        public int HP { get; private set; }
        public bool Dead { get
            {
                if (HP <= 0) return true;
                else return false;
            }
        }
        
        public Enemy(Game game,Point currentLoc, int HP, System.Windows.Controls.Image img):base(game,currentLoc,img)
        {
            this.HP = HP;
            this.img = img;
        }

        public abstract void Move(Random random);
        /*{
            int direction = rand.Next(0,8);
            if(!LookForPlayer(player))
            {
                if (direction == 0 && currY + 25 < max.Y)
                {
                    currY += 25;
                }
                else if (direction == 1 && currX + 25 < max.X)
                {
                    currX += 25;
                }
                else if (direction == 2 && currY - 25 > 0)
                {
                    currY -= 25;
                }
                else if(direction == 3 && currX - 25 > 0)
                {
                    currX -= 25;
                }
            }
            translate.X = currX;
            translate.Y = currY;
            rect.RenderTransform = translate;
            Translate = translate;
            //if (Nearby(player.CurrentLoc))
                //MessageBox.Show("hit");
        }*/
        public void Hit(int maxDamage, Random random)
        {
            HP -= random.Next(1, maxDamage);
        }

        protected bool NearPlayer()
        {
            return Nearby(game.PlayerLocation, NearPlayerDistance);
        }
        protected Direction FindPlayerDirection(Point playerLocation)
        {
            Direction directionToMove;
            if (playerLocation.X > location.X + 10)
                directionToMove = Direction.Right;
            else if (playerLocation.X < location.X - 10)
                directionToMove = Direction.Left;
            else if (playerLocation.Y < location.Y - 10)
                directionToMove = Direction.Up;
            else
                directionToMove = Direction.Down;
            return directionToMove;
        }
    }
}
