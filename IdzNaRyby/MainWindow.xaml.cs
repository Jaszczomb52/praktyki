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

        Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            game.Start(nameBox.Text);
            gibCard.IsEnabled = true;
            startButton.IsEnabled = false;
            nameBox.IsEnabled = false;
            RefreshHand(hand, game.GetPlayer());
        }
        
        private void GibCard_Click(object sender, RoutedEventArgs e)
        {
            if(game.CheckForTheEmptyDeck())
            {
                MessageBox.Show("Koniec gry!");
            }
            Player main = game.GetPlayer();
            game.Checker(main, hand.SelectedIndex,gameWindow,groups);
            RefreshHand(hand, main);
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
        
    }
}