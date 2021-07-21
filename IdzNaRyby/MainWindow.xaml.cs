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
        readonly Deck deck = new Deck();
        readonly Random rand = new Random();
        readonly List<Player> players = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start();
            RefreshHand(hand, players.Last());
        }
        
        private void Start()
        {
            gibCard.IsEnabled = true;
            startButton.IsEnabled = false;
            nameBox.IsEnabled = false;
            players.Add(GenerateOpponent("Zbychu"));
            players.Add(GenerateOpponent("Jacek"));
            players.Add(GenerateOpponent(nameBox.Text));

            //showOpCards();
        }


        private Deck StartCards(Deck playersDeck)
        {
            for(int i = 0; i<17;i++)
            {
                deck.Shuffle();
                playersDeck.Add(deck.Deal(rand.Next(deck.Count)));
            }
            return playersDeck;
        }

        private Player GenerateOpponent(string name)
        {
            Deck deck = StartCards(new Deck(new List<Card>()));
            Player player;
            player = new Player(deck, name);
            
            return player;
        }

        private void GibCard_Click(object sender, RoutedEventArgs e)
        {
            Player main = GetPlayer();
            Checker(main, hand.SelectedIndex) ;
            RefreshHand(hand, main);
        }

        private Player GetPlayer()
        {
            return players.Last();
        }

        private void Checker(Player checker, int selectedIndex)
        {
            if (selectedIndex >= 0)
            {

                foreach (Player opponent in players)
                {
                    
                    if (opponent.Name != checker.Name)
                    {
                        int temp = opponent.CheckForCards(checker.DeckOfPlayer.cards[selectedIndex]);
                        if (temp != 0)
                        {
                            gameWindow.Text += opponent.Name + " oddał " + temp + " kart \n";
                            checker.GiveCards(opponent, selectedIndex, deck);
                        }
                    }
                }
                CheckGroups(checker);
                //showOpCards();
            }
        }

        private void CheckGroups(Player player)
        {
            Card[] group = player.CheckForGroups();
            if(group[3] != null)
            {
                groups.Text += player.Name + " ma grupę " + group[0].Value + " \n";
            }

        }

        private void RefreshHand(ListBox hand, Player player)
        {

            hand.Items.Clear();
            player.DeckOfPlayer.Sort();
            foreach (string card in player.DeckOfPlayer.GetCardNames())
            {
                hand.Items.Add(card);
            }
        }

        // metoda debugowa

        private void ShowOpCards()
        {
            gameWindow.Text = "";
            foreach (Card card in players[0].DeckOfPlayer.cards)
            {
                gameWindow.Text += card.ToString() + "\n";
            }
            foreach (Card card in players[1].DeckOfPlayer.cards)
            {
                gameWindow.Text += card.ToString() + "\n";
            }
        }
    }
}