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
    abstract class Mover
    {
        public double currY;
        public double currX;
        public Point CurrentLoc { get { return new Point(currX, currY); } }
        public TranslateTransform Translate { get; set; }
        public Mover (Point currentLoc)
        {
            currY = currentLoc.Y;
            currX = currentLoc.X;
        }

        public bool Nearby(Point LocationToCheck)
        {
            Vector distance = new Point(currX,currY) - LocationToCheck;
            if (distance.X < 0)
                distance.X *= -1;
            if (distance.Y < 0)
                distance.Y *= -1;
            if (distance.X <= 25 && distance.Y == 0)
                return true;
            else if (distance.Y <= 25 && distance.X == 0)
                return true;
            else
                return false;
        }

        public double CheckDistance(Point LocationToCheck)
        {
            Vector distance = new Point(currX, currY) - LocationToCheck;
            return distance.Length;
        }
    }
}
