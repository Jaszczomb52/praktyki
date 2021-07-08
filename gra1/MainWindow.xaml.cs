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
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(1, 1);
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            canv.Background = brush;
        }
        Random rand = new Random();
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
            
        }
        private void AnimateEnemy(ContentControl cont, double p1, double p2, string p3)
        {

            Storyboard story = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = p1,
                To = p2,
                Duration = new Duration(TimeSpan.FromSeconds(rand.Next(2,3)))
            };
            Storyboard.SetTarget(animation, cont);
            Storyboard.SetTargetProperty(animation, new PropertyPath(p3));
            story.Children.Add(animation);
            story.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEnemy();
        }
    }
}
