using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Laboratorium2
{
    class Enemy : Mover
    {
        //TranslateTransform translate = new TranslateTransform();
        Random rand = new Random();
        int HP { get; set; }
        public Enemy(Point currentLoc, int HP):base(currentLoc)
        {
            this.HP = HP;
        }

        public void Move(Rectangle rect, Point max, Player player, TranslateTransform translate)
        {
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
        }

        private bool LookForPlayer(Player player)
        {
            double temp = CheckDistance(player.CurrentLoc);
            if(temp < 200 && rand.Next(0,2) == 1)
            {
                Vector vec = CurrentLoc - player.CurrentLoc;
                if (Math.Abs(vec.X) > Math.Abs(vec.Y))
                {
                    if (vec.X > 0)
                    {
                        currX -= 25;
                        return true;
                    }
                    else
                    {
                        currX += 25;
                        return true;
                    }
                }
                else
                {
                    if (vec.Y > 0)
                    {
                        currY -= 25;
                        return true;
                    }
                    else
                    {
                        currY += 25;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
