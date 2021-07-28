using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;

namespace Laboratorium2
{
    class Game
    {
        public List<Enemy> Enemies { get; private set; }
        public Weapon WeaponInRoom { get; private set; }

        private Player player;
        public Point PlayerLocation { get { return player.Location; } }
        public IEnumerable<string> PlayerWeapons { get { return player.Weapons; } }
        private int level = 0;
        public int Level { get { return level; } }

        private Rectangle boundaries;
        public Rectangle Boundaries { get { return boundaries; } }
        protected System.Windows.Controls.Image PlayerImg;
        protected System.Windows.Controls.Image GhostImg;
        protected System.Windows.Controls.Image GhoulImg;
        protected System.Windows.Controls.Image BatImg;
        protected System.Windows.Controls.Image BluePotion;
        protected System.Windows.Controls.Image RedPotion;

        public Game(Rectangle boundaries, System.Windows.Controls.Image GhostImg, System.Windows.Controls.Image GhoulImg, System.Windows.Controls.Image BatImg, System.Windows.Controls.Image PlayerImg, System.Windows.Controls.Image RedPotion, System.Windows.Controls.Image BluePotion)
        {
            this.boundaries = boundaries;
            player = new Player(this,new Point(boundaries.Left + 10, boundaries.Top + 70),PlayerImg);
            this.GhostImg = GhostImg;
            this.GhoulImg = GhoulImg;
            this.BatImg = BatImg;
            this.PlayerImg = PlayerImg;
            this.BluePotion = BluePotion;
            this.RedPotion = RedPotion;
        }
        public void Move(Direction direction, Random random)
        {
            //player.Move(direction);
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
            player.Hit(maxDamage, random);
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
        private Point GetRandomLocation(Random random)
        {
            return new Point(boundaries.Left +
                random.Next(boundaries.Right / 10 - boundaries.Left / 10) * 10,
                boundaries.Top +
                random.Next(boundaries.Bottom / 10 - boundaries.Top / 10) * 10);
        }
        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>();
                    resetCanvas();
                    Canvas.SetLeft(BatImg, random.Next(0, 570));
                    Enemies.Add(new Bat(this, GetRandomLocation(random), BatImg));
                    WeaponInRoom = new Sword(this, GetRandomLocation(random),RedPotion);
                    break;
                case 2:
                    Enemies = new List<Enemy>();
                    resetCanvas();
                    Canvas.SetLeft(GhostImg, random.Next(0, 570));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), GhostImg));
                    WeaponInRoom = new BluePotion(this, GetRandomLocation(random), BluePotion);
                    break;
                case 3:
                    Enemies = new List<Enemy>();
                    resetCanvas();
                    Canvas.SetLeft(GhoulImg, random.Next(0, 570));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random), GhoulImg));
                    WeaponInRoom = new Bow(this, GetRandomLocation(random),RedPotion);
                    break;
                case 4:
                    Enemies = new List<Enemy>();
                    resetCanvas();
                    Canvas.SetLeft(BatImg, random.Next(0, 570));
                    Canvas.SetLeft(GhoulImg, random.Next(0, 570));
                    Enemies.Add(new Bat(this, GetRandomLocation(random), BatImg));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random), GhoulImg));
                    if (!PlayerWeapons.Contains("Bow"))
                        WeaponInRoom = new Bow(this, GetRandomLocation(random),RedPotion);
                    else if (!PlayerWeapons.Contains("BluePotion"))
                        WeaponInRoom = new BluePotion(this, GetRandomLocation(random), BluePotion);
                    break;
                case 5:
                    Enemies = new List<Enemy>();
                    resetCanvas();
                    Canvas.SetLeft(BatImg, random.Next(0, 570));
                    Canvas.SetLeft(GhoulImg, random.Next(0, 570));
                    Enemies.Add(new Bat(this, GetRandomLocation(random), BatImg));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random), GhoulImg));
                    if (!PlayerWeapons.Contains("RedPotion"))
                        WeaponInRoom = new RedPotion(this, GetRandomLocation(random),RedPotion);
                    break;
                case 6:
                    Enemies = new List<Enemy>();
                    resetCanvas();
                    Canvas.SetLeft(GhostImg, random.Next(0, 570));
                    Canvas.SetLeft(GhoulImg, random.Next(0, 570));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), GhostImg));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random), GhoulImg));
                    if (!PlayerWeapons.Contains("Mace"))
                        WeaponInRoom = new Mace(this, GetRandomLocation(random),RedPotion);
                    break;
                case 7:
                    Enemies = new List<Enemy>();
                    resetCanvas();
                    Canvas.SetLeft(BatImg, random.Next(0, 570));
                    Canvas.SetLeft(GhostImg, random.Next(0, 570));
                    Canvas.SetLeft(GhoulImg, random.Next(0, 570));
                    Enemies.Add(new Bat(this, GetRandomLocation(random), BatImg));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), GhostImg));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random), GhoulImg));
                    if (!PlayerWeapons.Contains("Mace"))
                        WeaponInRoom = new Mace(this, GetRandomLocation(random),RedPotion);
                    if (!PlayerWeapons.Contains("RedPotion"))
                        WeaponInRoom = new RedPotion(this, GetRandomLocation(random),RedPotion);
                    break;
                case 8:
                    break;
            }
        }
        private void resetCanvas()
        {
            Canvas.SetLeft(BatImg, 1000);
            Canvas.SetLeft(GhostImg, 1000);
            Canvas.SetLeft(GhoulImg, 1000);
        }
    }
}
