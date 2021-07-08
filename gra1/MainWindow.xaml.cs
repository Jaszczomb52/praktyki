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
using System.Windows.Media.Effects;

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
            LinearGradientBrush brush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            canv.Background = brush;
            // interval przeciwnika
            enemyTimer.Tick += EnemyTimer_Tick;
            enemyTimer.Interval = TimeSpan.FromSeconds(2);
            // interval targetu
            targetTimer.Tick += TargetTimer_Tick;
            targetTimer.Interval = TimeSpan.FromSeconds(0.1);
            canv.Children.Clear();
            //logoFade();
        }


        //reakcja przeciwnika co tick
        private void EnemyTimer_Tick(object sender, EventArgs e)
        {
            AddEnemy();
        }

        //reakcja targetu(portalu) co tick
        private void TargetTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value += 1;
            if (progressBar.Value == progressBar.Maximum)
                End();
        }

        //reakcja na koniec gry
        private void End()
        {
            //dodanie elementow UI na koniec gry 
            canv.Children.Add(endText);
            canv.Children.Add(score);
            canv.Children.Add(coins);
            canv.Children.Add(best);
            //zatrzymanie timerow
            enemyTimer.Stop();
            targetTimer.Stop();
            humanCaptured = false;
            startButt.Visibility = Visibility.Visible;
            // sprawdzenie czy wynik jest rekordem, jesli tak zaktualizowanie
            if (Config.ChceckScore(int.Parse(points.Content.ToString())))
            {
                Config.UpdateScore(int.Parse(points.Content.ToString()));
                Config.UpdateCoins(int.Parse(aliens.Content.ToString()));
            }
            //wyswietlenie rekordu
            score.Content = Config.GetScore().ToString() + " punktów";
            coins.Content = Config.GetCoins().ToString() + " kosmitów";
        }

        //zmienne globalne
        readonly Random rand = new Random();
        readonly DispatcherTimer enemyTimer = new DispatcherTimer();
        readonly DispatcherTimer targetTimer = new DispatcherTimer();
        bool humanCaptured = false;

        //dodanie przeciwnika do canvasa
        private void AddEnemy()
        {
            //stworzenie przeciwnika jako elipsy bitcoin
            ContentControl enemy = new ContentControl();
            Ellipse el = new Ellipse
            {
                Width = 100,
                Height = 100
            };
            ImageBrush img = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("C:/Users/xopero/source/repos/Hello_world/gra1/OIP.jpg"))
            };
            el.Fill = img;
            //dodanie elipsy jako przeciwnika i animacja
            enemy.Content = el;
            AnimateEnemy(enemy, canv.ActualWidth - 100, 0, "(Canvas.Left)");
            AnimateEnemy(enemy, rand.Next((int)canv.ActualHeight-100),
                rand.Next((int)canv.ActualHeight-100), "(Canvas.Top)");
            canv.Children.Add(enemy);
            // sprawdzanie czy mysz najechala na wroga i zliczanie wrogow
            enemy.MouseEnter += Enemy_MouseEntered;
            aliens.Content = int.Parse(aliens.Content.ToString()) + 1;
        }
        // metoda sprawdzajaca czy ludzik najechal na wroga
        private void Enemy_MouseEntered(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
            {
                End();
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
            Start();
        }
        // start gry
        private void Start()
        {
            // pokazanie rzeczy w canvasie i UI oraz rozpoczecie gry
            human.IsHitTestVisible = true;
            humanCaptured = false;
            progressBar.Value = 0;
            startButt.Visibility = Visibility.Collapsed;
            canv.Children.Clear();
            canv.Children.Add(human);
            canv.Children.Add(portal);
            enemyTimer.Start();
            targetTimer.Start();
            points.Content = 0;
            aliens.Content = 0;
            Canvas.SetLeft(portal, rand.Next(100, (int)canv.ActualWidth - 100));
            Canvas.SetTop(portal, rand.Next(100, (int)canv.ActualHeight - 100));
            Canvas.SetLeft(human, rand.Next(100, (int)canv.ActualWidth - 100));
            Canvas.SetTop(human, rand.Next(100, (int)canv.ActualHeight - 100));
        }

        private void Human_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   //wykrywanie przejecia kontroli nad ludzikiem
            if (enemyTimer.IsEnabled)
            {
                humanCaptured = true;
                human.IsHitTestVisible = false;
            }
        }

        private void Portal_MouseEnter(object sender, MouseEventArgs e)
        {   // rozpoczecie rundy
            if(targetTimer.IsEnabled&&humanCaptured)
            {
                progressBar.Value = 0;
                Canvas.SetLeft(portal, rand.Next(100, (int)canv.ActualWidth - 100));
                Canvas.SetTop(portal, rand.Next(100, (int)canv.ActualHeight - 100));
                Canvas.SetLeft(human, rand.Next(100, (int)canv.ActualWidth - 100));
                Canvas.SetTop(human, rand.Next(100, (int)canv.ActualHeight - 100));
                points.Content = int.Parse(points.Content.ToString()) + 1;
            }
        }

        private void Canv_MouseMove(object sender, MouseEventArgs e)
        {   // ruch ludzika za myszka
            if (humanCaptured)
            {
                double x = e.GetPosition(null).X;
                double y = e.GetPosition(null).Y;
                Point position = new Point(x, y);
                Point relativePos = grid.TransformToVisual(canv).Transform(position);
                // jesli ruch jest za szybki puszczenie ludzika
                if ((Math.Abs(relativePos.X - Canvas.GetLeft(human)) > human.ActualWidth * 3)
                    || (Math.Abs(relativePos.Y - Canvas.GetTop(human)) > human.ActualHeight * 3))
                {
                    humanCaptured = false;
                    human.IsHitTestVisible = true;
                }
                else
                {   // jesli nie, podazanie
                    Canvas.SetLeft(human, relativePos.X - human.ActualWidth / 2);
                    Canvas.SetTop(human, relativePos.Y - human.ActualHeight / 2);
                }
            }        
        }

        private void Canv_MouseLeave(object sender, MouseEventArgs e)
        {   //koniec gry jesli kursor z ludzikiem wyjedzie poza canvas
            if (humanCaptured)
            {
                End();
            }
        }

        private void LogoFade()
        {
            
           /*Storyboard story = new Storyboard() { AutoReverse = false};
            DoubleAnimation animation = new DoubleAnimation()
            {
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(5)),
                FillBehavior = FillBehavior.Stop
            };
            animation.Completed += (s, a) => startScreen.Visibility = Visibility.Hidden;
            startScreen.BeginAnimation(UIElement.OpacityProperty, animation);*/
        }
    }
}
