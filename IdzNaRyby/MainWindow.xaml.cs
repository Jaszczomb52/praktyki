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
            MainPlayer player = players[2] as MainPlayer;
            player.RefreshHand(hand);
        }
        
        private void Start()
        {
            gibCard.IsEnabled = true;
            startButton.IsEnabled = false;
            nameBox.IsEnabled = false;
            players.Add(GenerateOpponent("Zbychu", true));
            players.Add(GenerateOpponent("Jacek", true));
            players.Add((MainPlayer)GenerateOpponent(nameBox.Text,false));

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


        private Deck startCards(Deck playersDeck)
        {
            for(int i = 0; i<5;i++)
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
            if (opponent)
            {
                player = new Player(deck, name);
            }
            else
            {
                player = new MainPlayer(deck, name);
            }
            return player;
        }

        private void gibCard_Click(object sender, RoutedEventArgs e)
        {
            MainPlayer player = players[2] as MainPlayer;
            player.GiveCards(players, hand.SelectedIndex);
            player.RefreshHand(hand);

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
