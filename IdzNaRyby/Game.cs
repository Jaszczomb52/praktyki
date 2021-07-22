using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IdzNaRyby
{
    class Game
    {
        readonly Deck deck = new Deck();
        readonly Random rand = new Random();
        readonly List<Player> players = new List<Player>();

        public Game()
        {

        }

        public Player GetPlayer()
        {
            return players.Last();
        }

        public void Checker(Player checker, int selectedIndex, TextBox gameWindow, TextBox groups)
        {
            bool hasCards = false;
            if (selectedIndex >= 0)
            {

                foreach (Player opponent in players)
                {

                    if (opponent.Name != checker.Name)
                    {
                        int temp = opponent.CheckForCards(checker.DeckOfPlayer.cards[selectedIndex]);
                        if (temp != 0)
                        {
                            hasCards = true;
                            gameWindow.Text += opponent.Name + " oddał " + temp + " kart \n";
                            checker.GiveCards(opponent, selectedIndex, deck);
                        }
                    }
                }
                if(!hasCards)
                {
                    checker.GiveCards(checker, rand.Next(deck.Count), deck);
                }
                CheckGroups(checker, groups);
                //showOpCards();
            }
        }

        public void Start(string name)
        {

            players.Add(GenerateOpponent("Zbychu"));
            players.Add(GenerateOpponent("Jacek"));
            players.Add(GenerateOpponent(name));

            //showOpCards();
        }

        public bool CheckForTheEmptyDeck()
        {
            if(deck.Count == 0)
            {
                return true;
            }
            return false;
        }

        private void ShowOpCards(TextBox gameWindow)
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

        private void CheckGroups(Player player, TextBox groups)
        {
            Card[] group = player.CheckForGroups();
            if (group[3] != null)
            {
                groups.Text += player.Name + " ma grupę " + group[0].Value + " \n";
            }
        }

        
        private Player GenerateOpponent(string name)
        {
            Deck deck = StartCards(new Deck(new List<Card>()));
            Player player;
            player = new Player(deck, name);

            return player;
        }

        private Deck StartCards(Deck playersDeck)
        {
            for (int i = 0; i < 17; i++)
            {
                deck.Shuffle();
                playersDeck.Add(deck.Deal(rand.Next(deck.Count)));
            }
            return playersDeck;
        }
    }
}
