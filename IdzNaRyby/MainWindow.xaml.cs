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
            RefreshHand(2);
        }
        
        private void Start()
        {
            gibCard.IsEnabled = true;
            startButton.IsEnabled = false;
            nameBox.IsEnabled = false;
            players.Add(GenerateOpponent("Zbychu"));
            players.Add(GenerateOpponent("Jacek"));
            players.Add(GenerateOpponent(nameBox.Text));

            foreach (string card in players[0].deckOfPlayer.GetCardNames())
            {
                gameWindow.Text += card + "\n";
            }
            foreach (string card in players[1].deckOfPlayer.GetCardNames())
            {
                gameWindow.Text += card + "\n";
            }
        }

        private void RefreshHand(int i)
        {
            hand.Items.Clear();
            foreach (string card in players[i].deckOfPlayer.GetCardNames())
            {
                hand.Items.Add(card);
            }

        }

        private Deck startCards(Deck playersDeck)
        {
            for(int i = 0; i<5;i++)
            {
                deck.Shuffle();
                playersDeck.Add(deck.Deal(rand.Next(deck.Count)));
            }
            return playersDeck;
        }

        private Player GenerateOpponent(string name)
        {
            Deck deck = startCards(new Deck(new List<Card>()));
            Player player = new Player(deck, name);
            return player;
        }

        private void AskForCards(Player player, Card card)
        { 
            for(int j = 0; j < 2; j ++)
            {
                for(int i = 0; i < players[j].deckOfPlayer.Count;i++)
                {
                    if (players[j].deckOfPlayer.Check(card))
                    {
                        if(players[j].deckOfPlayer.cards[i].Value == card.Value)
                        {
                            player.deckOfPlayer.Add(players[j].deckOfPlayer.Deal(i));
                        }
                    }
                }
            }
        }

        private void gibCard_Click(object sender, RoutedEventArgs e)
        {
            AskForCards(players[2], players[2].deckOfPlayer.cards[hand.SelectedIndex]);
            RefreshHand(2);
            gameWindow.Text = "";
            foreach (string card in players[0].deckOfPlayer.GetCardNames())
            {
                gameWindow.Text += card + "\n";
            }
            foreach (string card in players[1].deckOfPlayer.GetCardNames())
            {
                gameWindow.Text += card + "\n";
            }
        }
    }
}
