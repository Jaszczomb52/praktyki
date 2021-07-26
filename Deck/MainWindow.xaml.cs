using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            MessageBox.Show(card.ToString());
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
            CardComparer cardComp = new CardComparer();
            cardComp.SortBy = SortCriteria.Suit;
            table.Sort(cardComp);
            string report = "Ręka kasyna: \n";
            foreach(Card card in table)
            {
                report += card + " \n";   
            }
            report += "\n\nTwoja ręka: \n";
            foreach(Card card in hand)
            {
                report += card + " \n";
            }
            MessageBox.Show(report);
        }

        private void SuitClick(object sender, RoutedEventArgs e)
        {
            Card card = getCard();
            if (Card.DoesCardMatch(card, Suits.Hearts))
                MessageBox.Show("Wylosowana przez Ciebie karta - " + card + " jest typu serce!");
            else
                MessageBox.Show("Wylosowana przez Ciebie karta - " + card + " nies jest typu serce.");

        }

        private void ValueClick(object sender, RoutedEventArgs e)
        {
            Card card = getCard();
            if (Card.DoesCardMatch(card, Values.Ace))
                MessageBox.Show("Wylosowana przez Ciebie karta - " + card + " to as!");
            else
                MessageBox.Show("Wylosowana przez Ciebie karta - " + card + " to nie as");
        }

        private void SerializeClick(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream output = File.Create("C:\\Users\\cmdrb\\documents\\karta1.dat"))
            {
                formatter.Serialize(output, getCard());
            }
            using (Stream output = File.Create("C:\\Users\\cmdrb\\documents\\karta2.dat"))
            {
                formatter.Serialize(output, getCard());
            }
        }
    }
}
