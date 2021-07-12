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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zaklady
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Typo[] typy = {new Typo(50, "Zbychu"), new Typo(50, "Stachu"), new Typo(50, "Mirek")};
        Random rand = new Random();
        List<ContentControl> dogs;
        public MainWindow()
        {
            InitializeComponent();
            Load();
            this.dogs = new List<ContentControl> { d1, d2, d3, d4 };
        }

        private void Load()
        {
            RadioButton[] typyRad = { ZbychuRad, StachuRad, MirekRad };
            for(int i = 0;i<3;i++)
            typyRad[i].Content =typy[i].name + " ma " + typy[i].money + "zł";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private double Start(ContentControl dog)
        {
            Storyboard story = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = 0,
                To = track.Width-imgDog.Width,
                Duration = new Duration(TimeSpan.FromSeconds(rand.Next(4, 15)))
            };
            story.Children.Add(animation);
            Storyboard.SetTarget(animation, dog);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Left)"));
            story.Children.Add(animation);
            story.Begin();
            return (double)animation.Duration.TimeSpan.TotalSeconds;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double[] times = {0,0,0,0};
            for(int i=0;i<4;i++)
            {
                repeat:
                double temp = Start(dogs[i]);
                for (int j = 0; j < 4; j++)
                {
                    if(times[j] == temp)
                    {
                        goto repeat;
                    }
                }
                times[i] = temp;
            }
        }
    }
}
