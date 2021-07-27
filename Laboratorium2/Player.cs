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
        public Player(Game game, Point currentLoc) :base(game,currentLoc)
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

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if(!game.WeaponInRoom.PickedUp)
            {

            }
        }

        public void Attack(Direction direction, Random random)
        {

        }
    }
}
