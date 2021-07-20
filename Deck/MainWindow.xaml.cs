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

namespace Deck
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void randomCard(object sender, RoutedEventArgs e)
        {
            Card card = getCard();
            MessageBox.Show(card.Name);
        }

        private Card getCard()
        {
             return new Card((Suits)rand.Next(4), (Values)rand.Next(1, 14));
        }

        private void randomHands(object sender, RoutedEventArgs e)
        {
            List<Card> table = new List<Card>
            {
                getCard(),
                getCard(),
                getCard(),
                getCard(),
                getCard(),
            };

            List<Card> hand = new List<Card>
            {
                getCard(),
                getCard(),
            };
            CardComparer card = new CardComparer();
            card.SortBy = SortCriteria.Suit;
            table.Sort(card);
            string report = "Ręka kasyna: \n";
            for(int i = 0;i<5;i++)
            {
                report += table[i].Name + " \n";   
            }
            report += "\n\nTwoja ręka: \n";
            for(int i = 0;i<2;i++)
            {
                report += hand[i].Name + " \n";
            }
            MessageBox.Show(report);
        }
    }
}
