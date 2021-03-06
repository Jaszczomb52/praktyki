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

        readonly Game game;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game(gameWindow, groups, gibCard);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            gibCard.IsEnabled = true;
            game.Start(nameBox.Text);
            startButton.IsEnabled = false;
            nameBox.IsEnabled = false;
            game.GetPlayer().CheckForGroups();
            game.RefreshHand(hand, game.GetPlayer());
            
            game.GameLoop(hand);
            game.tcs?.TrySetResult(true);
        }
        
        private void GibCard_Click(object sender, RoutedEventArgs e)
        {
            bool temp = false;
            Player main = game.GetPlayer();
            temp = game.Checker(main, hand.SelectedIndex);
            game.RefreshHand(hand, main);
            if(temp)
                game.tcs?.TrySetResult(true);
        }

        
        
    }
}