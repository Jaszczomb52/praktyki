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

namespace TwoDecks
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Deck deck1;
        Deck deck2;
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            ResetDeck(1);
            ResetDeck(2);
            RedrawDeck(1);
            RedrawDeck(2);
        }


        private void ResetDeck(int i)
        {
            if (i == 1)
            {
                int numberOfCards = rand.Next(1, 11);
                deck1 = new Deck(new Card[] { });
                for (int j = 0; j < numberOfCards; j++)
                {
                    deck1.Add(new Card((Suits)rand.Next(4), (Values)rand.Next(1, 14)));
                }
                deck1.Sort();
            }
            else
            {
                deck2 = new Deck();
            }
        }

        private void RedrawDeck(int deckNumber)
        {
            if(deckNumber == 1)
            {
                List1.Items.Clear();
                foreach(string card in deck1.GetCardNames())
                {
                    List1.Items.Add(card);
                }
                firstDeck.Content = "Zestaw 1 (" + deck1.Count + " kart)";
            }
            else
            {
                List2.Items.Clear();
                foreach(string card in deck2.GetCardNames())
                {
                    List2.Items.Add(card);
                }
                secondDeck.Content = "Zestaw 2 (" + deck2.Count + " kart)";
            }
        }

        private Card GetCard()
        {
            return new Card((Suits)rand.Next(4),(Values)rand.Next(1,14));
        }

        private void reset1_Click(object sender, RoutedEventArgs e)
        {
            ResetDeck(1);
            RedrawDeck(1);
        }

        private void reset2_Click(object sender, RoutedEventArgs e)
        {
            ResetDeck(2);
            RedrawDeck(2);
        }

        private void shuffle1_Click(object sender, RoutedEventArgs e)
        {
            deck1.Shuffle();
            RedrawDeck(1);
        }

        private void shuffle2_Click(object sender, RoutedEventArgs e)
        {
            deck2.Shuffle();
            RedrawDeck(2);
        }

        private void moveToDeck1_Click(object sender, RoutedEventArgs e)
        {
            if(List2.SelectedIndex>=0)
            {
                if(deck2.Count > 0)
                {
                    deck1.Add(deck2.Deal(List2.SelectedIndex));
                }
            }
            RedrawDeck(1);
            RedrawDeck(2);
        }

        private void moveToDeck2_Click(object sender, RoutedEventArgs e)
        {
            if (List1.SelectedIndex >= 0)
            {
                if (deck1.Count > 0)
                {
                    deck2.Add(deck1.Deal(List1.SelectedIndex));
                }
            }
            RedrawDeck(1);
            RedrawDeck(2);
        }
    }
}
