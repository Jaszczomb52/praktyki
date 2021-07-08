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
using System.Windows.Threading;

namespace gra1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // gradient brush tla
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(1, 1);
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            canv.Background = brush;
            // interval przeciwnika
            enemyTimer.Tick += enemyTimer_Tick;
            enemyTimer.Interval = TimeSpan.FromSeconds(2);
            // interval targetu
            targetTimer.Tick += targetTimer_Tick;
            targetTimer.Interval = TimeSpan.FromSeconds(0.1);
            canv.Children.Clear();
        }

        //reakcja przeciwnika co tick
        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            AddEnemy();
        }

        //reakcja targetu co tick
        private void targetTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value += 1;
            if (progressBar.Value == progressBar.Maximum)
                end();
        }

        //reakcja na koniec gry
        private void end()
        {
            canv.Children.Add(endText);
            enemyTimer.Stop();
            targetTimer.Stop();
            humanCaptured = false;
            startButt.Visibility = Visibility.Visible;
        }

        //zmienne globalne
        Random rand = new Random();
        DispatcherTimer enemyTimer = new DispatcherTimer();
        DispatcherTimer targetTimer = new DispatcherTimer();
        bool humanCaptured = false;

        //dodanie przeciwnika do canvasa
        private void AddEnemy()
        {
            ContentControl enemy = new ContentControl();
            Ellipse el = new Ellipse();
            el.Width = 100;
            el.Height = 100;
            Canvas.SetLeft(el, 500);
            
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri("C:/Users/xopero/Downloads/OIP.jpg"));
            
            el.Fill = img;
            enemy.Content = el;
            AnimateEnemy(enemy, canv.ActualWidth - 100, 0, "(Canvas.Left)");
            AnimateEnemy(enemy, rand.Next((int)canv.ActualHeight-100),
                rand.Next((int)canv.ActualHeight-100), "(Canvas.Top)");
            canv.Children.Add(enemy);

            enemy.MouseEnter += enemy_MouseEntered;
        }

        private void enemy_MouseEntered(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
            {
                end();
            }
        }

        //animowanie przeciwnika
        private void AnimateEnemy(ContentControl cont, double p1, double p2, string p3)
        {

            Storyboard story = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = p1,
                To = p2,
                Duration = new Duration(TimeSpan.FromSeconds(rand.Next(4,8)))
            };
            Storyboard.SetTarget(animation, cont);
            Storyboard.SetTargetProperty(animation, new PropertyPath(p3));
            story.Children.Add(animation);
            story.Begin();
        }

        //klikniecie przycisku start
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AddEnemy();
            start();
        }

        private void start()
        {
            human.IsHitTestVisible = true;
            humanCaptured = false;
            progressBar.Value = 0;
            startButt.Visibility = Visibility.Collapsed;
            canv.Children.Clear();
            canv.Children.Add(human);
            canv.Children.Add(portal);
            enemyTimer.Start();
            targetTimer.Start();
        }

        private void human_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (enemyTimer.IsEnabled)
            {
                humanCaptured = true;
                human.IsHitTestVisible = false;
            }
        }

        private void portal_MouseEnter(object sender, MouseEventArgs e)
        {
            if(targetTimer.IsEnabled&&humanCaptured)
            {
                progressBar.Value = 0;
                Canvas.SetLeft(portal, rand.Next(100, (int)canv.ActualWidth - 100));
                Canvas.SetTop(portal, rand.Next(100, (int)canv.ActualHeight - 100));
                Canvas.SetLeft(human, rand.Next(100, (int)canv.ActualWidth - 100));
                Canvas.SetTop(human, rand.Next(100, (int)canv.ActualHeight - 100));
            }
        }

        private void canv_MouseMove(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
            {
                double x = e.GetPosition(null).X;
                double y = e.GetPosition(null).Y;
                Point position = new Point(x, y);
                Point relativePos = grid.TransformToVisual(canv).Transform(position);
                if ((Math.Abs(relativePos.X - Canvas.GetLeft(human)) > human.ActualWidth * 3)
                    || (Math.Abs(relativePos.Y - Canvas.GetTop(human)) > human.ActualHeight * 3))
                {
                    humanCaptured = false;
                    human.IsHitTestVisible = true;
                }
                else
                {
                    Canvas.SetLeft(human, relativePos.X - human.ActualWidth / 2);
                    Canvas.SetTop(human, relativePos.Y - human.ActualHeight / 2);
                }
            }
        }

        private void canv_MouseLeave(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
            {
                end();
            }
        }
    }
}
