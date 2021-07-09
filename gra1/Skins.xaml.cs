using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace gra1
{
    /// <summary>
    /// Logika interakcji dla klasy Skins.xaml
    /// </summary>
    public partial class Skins : Window
    {
        Ellipse ep;
        public Skins(Ellipse ep)
        {
            InitializeComponent();
            this.ep = ep;
        }

        private void EthClick(object sender, RoutedEventArgs e)
        {
            Config.SetSkin("eth");
            ep.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/gra1;component/eth.jpg")));
        }

        private void BtcClick(object sender, RoutedEventArgs e)
        {
            Config.SetSkin("btc");
            ep.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/gra1;component/OIP.jpg")));
        }
    }
}
