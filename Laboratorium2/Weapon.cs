using System;
using System.Drawing;
using System.Windows;

namespace Laboratorium2
{
    abstract class Weapon : Mover
    {
        public bool PickedUp { get; set; }

        public Weapon(Game game, System.Windows.Point location):base(game, location)
        {
            PickedUp = false;
        }

        public void PickUpWeapon()
        {
            PickedUp = true;
        }

        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);
        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            System.Windows.Point target = game.PlayerLocation;
            for(int distance = 0; distance < radius; distance++)
            {
                foreach(Enemy enemy in game.Enemies)
                {
                    if(Nearby(enemy.Location, target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, target, game.Boundaries);
            }
            return false;
        }

        private bool Nearby(System.Windows.Point location, System.Windows.Point target, int distance)
        {
            return false;
        }

        private System.Windows.Point Move(Direction direction, System.Windows.Point target, Rectangle boundaries)
        {
            return target;
        }
    }
}