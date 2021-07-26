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
        int currY = 0;
        int currX = 0;
        double maxX;
        double maxY;

        public MainWindow()
        {
            InitializeComponent();
            maxX = canvas.Width-(rect.Width/2);
            maxY = canvas.Height-(rect.Height/2);
            TranslateTransform translate = new TranslateTransform();
            translate.X = currX += 0;
            translate.Y = currY += 100;
            rect.RenderTransform = translate;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                if(currY+25 < maxY)
                {
                    TranslateTransform translate = new TranslateTransform();
                    translate.X = currX += 0;
                    translate.Y = currY += 25;
                    rect.RenderTransform = translate;
                }
            }
            if (e.Key == Key.W)
            {
                if(currY - 25 >= 0)
                {
                    TranslateTransform translate = new TranslateTransform();
                    translate.X = currX += 0;
                    translate.Y = currY -= 25;
                    rect.RenderTransform = translate;
                }
            }
            if (e.Key == Key.A)
            {
                if(currX - 25 >= 0)
                {
                    TranslateTransform translate = new TranslateTransform();
                    translate.X = currX -= 25;
                    translate.Y = currY += 0;
                    rect.RenderTransform = translate;
                }
            }
            if (e.Key == Key.D)
            {
                if(currX + 25 < maxX)
                {
                    TranslateTransform translate = new TranslateTransform();
                    translate.X = currX += 25;
                    translate.Y = currY += 0;
                    rect.RenderTransform = translate;
                }
            }
        }
    }
}
