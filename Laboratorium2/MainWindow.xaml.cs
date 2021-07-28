using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Timers;

namespace Laboratorium2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;
        private Random random = new Random();
        private System.Drawing.Rectangle playerRect = new System.Drawing.Rectangle() { Width = 25, Height = 25 };
        Player player;
        public MainWindow()
        {
            InitializeComponent();
            game = new Game(new System.Drawing.Rectangle() { Width = 600, Height = 200, Location = new System.Drawing.Point(96, 77) },GhostImg,GhoulImg,BatImg);
            player = new Player(game,new System.Drawing.Point());
            game.NewLevel(random);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.D)
                player.Move(Direction.Right,playerImg);
            else if(e.Key == Key.S)
                player.Move(Direction.Down, playerImg);
            else if (e.Key == Key.A)
                player.Move(Direction.Left, playerImg);
            else if (e.Key == Key.W)
                player.Move(Direction.Up, playerImg);
            game.Move(Direction.Down, random);
            if(Canvas.GetLeft(playerImg) > 570)
            {
                game.NewLevel(random);
            }
        }
    }
}
