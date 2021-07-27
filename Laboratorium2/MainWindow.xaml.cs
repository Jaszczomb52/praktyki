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
        List<Enemy> enemies;
        Player player;
        Point max = new Point();
        TranslateTransform translate2 = new TranslateTransform
        {
            X = 100,
            Y = 150
        };

        public MainWindow()
        {
            InitializeComponent();
            enemies = new List<Enemy> { new Enemy(new Point(100, 150),25) };
            player = new Player(new Point(0, 100), enemies, inRange,100);
            max.X = canvas.Width-(rect.Width/2);
            max.Y = canvas.Height-(rect.Height/2);
            TranslateTransform translate = new TranslateTransform
            {
                X = 0,
                Y = 100
            };
            
            rect.RenderTransform = translate;
            enemy.RenderTransform = translate2;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            player.Move(e, rect, max);
            enemies[0].Move(enemy, max, player, translate2);
            enemies[0].CheckDistance(player.CurrentLoc);
        }
    }
}
