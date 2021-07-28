using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Laboratorium2
{
    class Player : Mover
    {
        private Weapon equippedWeapon;
        public int HP { get; private set; }
        private List<Weapon> inventory = new List<Weapon>();
        public IEnumerable<string> Weapons { 
            get 
                {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
                }
        }
        public Player(Game game, System.Drawing.Point currentLoc) :base(game,currentLoc)
        {
            HP = 10;
        }

        public void Hit(int maxDamage, Random random)
        {
            HP -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            HP += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach(Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon;
            }
        }

        public void Move(Direction direction, System.Windows.Controls.Image player)
        {
            if (direction == Direction.Right && Canvas.GetLeft(player) < 575)
                Canvas.SetLeft(player, Canvas.GetLeft(player) + 10);
            else if (direction == Direction.Down && Canvas.GetTop(player) < 175)
                Canvas.SetTop(player, Canvas.GetTop(player) + 10);
            else if (direction == Direction.Left && Canvas.GetLeft(player) > 0)
                Canvas.SetLeft(player, Canvas.GetLeft(player) - 10);
            else if (direction == Direction.Up && Canvas.GetTop(player) > 0)
                Canvas.SetTop(player, Canvas.GetTop(player) - 10);
            /*if(!game.WeaponInRoom.PickedUp)
            {

            }*/
        }

        public void Attack(Direction direction, Random random)
        {

        }
    }
}
