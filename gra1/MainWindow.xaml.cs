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
            canv.CaptureMouse();
            ContentControl content = new ContentControl();
            content.Template = Resources["templ"] as ControlTemplate;
            Anim(content, 0, canv.ActualWidth - 100, "(Canvas.Left)");
        }

        private void Anim(ContentControl cont, double p1, double p2, string p3)
        {
            Storyboard story = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = p1,
                To = p2,
                Duration = new Duration(TimeSpan.FromSeconds(10))
            };
            Storyboard.SetTarget(animation, enemy);
            Storyboard.SetTargetProperty(animation, new PropertyPath(p3));
            story.Children.Add(animation);
            story.Begin();
        }
    }
}
