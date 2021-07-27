using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Laboratorium2
{
    class Player : Mover
    {
        public IEnumerable<string> Weapons { get; set; }
        int HP { get; set; }
        List<Enemy> EnemiesInRange { get; set; }
        List<Enemy> Enemies { get; set; }
        Label Label;
        Random rand = new Random();
        public Player(Point currentLoc) :base(currentLoc)
        {
            //Enemies = enemy;
            EnemiesInRange = new List<Enemy>();
            //Label = label;
            this.HP = HP;
        }

        public void Move(KeyEventArgs e, Rectangle rect, Point max)
        {
            if (e.Key == Key.S)
            {
                if (currY + 25 < max.Y)
                {
                    TranslateTransform translate = new TranslateTransform
                    {
                        X = currX += 0,
                        Y = currY += 25
                    };
                    rect.RenderTransform = translate;
                }
            }
            if (e.Key == Key.W)
            {
                if (currY - 25 >= 0)
                {
                    TranslateTransform translate = new TranslateTransform
                    {
                        X = currX += 0,
                        Y = currY -= 25
                    };
                    rect.RenderTransform = translate;
                }
            }
            if (e.Key == Key.A)
            {
                if (currX - 25 >= 0)
                {
                    TranslateTransform translate = new TranslateTransform
                    {
                        X = currX -= 25,
                        Y = currY += 0
                    };
                    rect.RenderTransform = translate;
                }
            }
            if (e.Key == Key.D)
            {
                if (currX + 25 < max.X)
                {
                    TranslateTransform translate = new TranslateTransform
                    {
                        X = currX += 25,
                        Y = currY += 0
                    };
                    rect.RenderTransform = translate;
                }
            }
            CheckTheRange();
        }

        private void CheckTheRange()
        {
            EnemiesInRange.Clear();
            foreach(Enemy enemy in Enemies)
            {
                Vector vec = CurrentLoc - enemy.CurrentLoc;
                if (vec.X <= 25 && vec.X >= -25 && vec.Y <= 25 && vec.Y >= -25)
                {
                    EnemiesInRange.Add(enemy);
                    if (EnemiesInRange.Count != 0)
                        Label.Content = EnemiesInRange.First().ToString();
                }
                else
                    Label.Content = "Brak";
            }
        }

        public void Attack()
        {

        }
    }
}
