using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace Laboratorium2
{
    class Game
    {
        public IEnumerable<Enemy> Enemies { get; private set; }
        public Weapon WeaponInRoom { get; private set; }

        private Player player;
        public System.Windows.Point PlayerLocation { get { return player.CurrentLoc; } }
        public IEnumerable<string> PlayerWeapons { get { return player.Weapons; } }
        private int level = 0;
        public int Level { get { return level; } }

        private Rectangle boundaries;
        public Rectangle Boundaries { get { return boundaries; } }

        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            player = new Player(new System.Windows.Point(boundaries.Left + 25, boundaries.Top + 75));
        }
        public void Move(Direction direction, Random random)
        {
            player.Move(direction);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }
        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }
        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }
        public void HitPlayer(int maxDamage, Random random)
        {
            Player.Hit(maxDamage, random);
        }
        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }
        public void Attack(Direction direction, Random random)
        {
            player.Attack(direction, random);
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }
        private System.Windows.Point GetRandomLocation(Random random)
        {
            return new System.Windows.Point(boundaries.Left +
                random.Next(boundaries.Right / 10 - boundaries.Left / 10) * 10,
                boundaries.Top +
                random.Next(boundaries.Bottom / 10 - boundaries.Top / 10) * 10);
        }
        public void NewLevel(Random random)
        {
            level++;
            switch(level)
            {
                case 1:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random)));
                    WeaponInRoom = new Swrod(this, GetRandomLocation(random));
                    break;
                case 2:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    if (!player.Items.Contains("BluePotion"))
                        WeaponInRoom = new Potion(this, GetRandomLocation(random));
                    break;
                case 3:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Ghoul(this, GetRandomLocation()));
                    Enemies.Add(new Ghost(this, GetRandomLocation()));l
            }
        }
    }
}
