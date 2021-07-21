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

namespace IdzNaRyby
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        Random rand = new Random();
        List<Player> players = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start();
            Player player = players[2];
            RefreshHand(hand,player);
        }
        
        private void Start()
        {
            gibCard.IsEnabled = true;
            startButton.IsEnabled = false;
            nameBox.IsEnabled = false;
            players.Add(GenerateOpponent("Zbychu", true));
            players.Add(GenerateOpponent("Jacek", true));
            players.Add(GenerateOpponent(nameBox.Text,false));

            showOpCards();
        }


        private Deck startCards(Deck playersDeck)
        {
            for(int i = 0; i<17;i++)
            {
                deck.Shuffle();
                playersDeck.Add(deck.Deal(rand.Next(deck.Count)));
            }
            return playersDeck;
        }

        private Player GenerateOpponent(string name, bool opponent)
        {
            Deck deck = startCards(new Deck(new List<Card>()));
            Player player;
            player = new Player(deck, name);
            
            return player;
        }

        private void gibCard_Click(object sender, RoutedEventArgs e)
        {
            Player main = GetPlayer();
            Checker(main);
            RefreshHand(hand, main);
        }

        private Player GetPlayer()
        {
            return players.Last();
        }

        private void Checker(Player checker)
        {
            if (hand.SelectedIndex >= 0)
            {

                foreach (Player opponent in players)
                {
                    
                    if (opponent.Name != checker.Name)
                    {
                    repeat:
                        int temp = opponent.CheckForCards(checker.deckOfPlayer.cards[hand.SelectedIndex]);
                        if (temp != 0)
                        {
                            // dodac w przyszlosci wyswietlanie ile kart (liuczba z tempa) ma dany gracz
                            gameWindow.Text += checker.Name + " ma " + temp + " kart \n";
                            checker.GiveCards(players, hand.SelectedIndex, deck);
                            goto repeat;
                        }
                    }
                }
                CheckGroups(checker);
                showOpCards();
            }
        }

        private void CheckGroups(Player player)
        {
            Card[] group = player.checkForGroups();
            if(group[3] != null)
            {
                groups.Text += player.Name + " ma grupę " + group[0].Value + " \n";
            }

        }

        private void RefreshHand(ListBox hand, Player player)
        {

            hand.Items.Clear();
            player.deckOfPlayer.Sort();
            foreach (string card in player.deckOfPlayer.GetCardNames())
            {
                hand.Items.Add(card);
            }
        }

        // metoda debugowa

        private void showOpCards()
        {
            gameWindow.Text = "";
            foreach (Card card in players[0].deckOfPlayer.cards)
            {
                gameWindow.Text += card.ToString() + "\n";
            }
            foreach (Card card in players[1].deckOfPlayer.cards)
            {
                gameWindow.Text += card.ToString() + "\n";
            }
        }
    }
}