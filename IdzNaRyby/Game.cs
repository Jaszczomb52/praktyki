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
        readonly TextBox gameWindow;
        readonly TextBox groups;
        readonly Button gibCardButton;
        public TaskCompletionSource<bool> tcs = null;
        

        public Game(TextBox GameWindow, TextBox Groups, Button GibCardButton)
        {
            gameWindow = GameWindow;
            groups = Groups;
            gibCardButton = GibCardButton;
        }

        public Player GetPlayer()
        {
            return players.First();
        }

        public void Checker(Player checker, int selectedIndex)
        {
            bool hasDeal = false;
            if (selectedIndex >= 0)
            {
                gameWindow.Text += checker.Name + " chce dostać karty o nominale" + checker.DeckOfPlayer.cards[selectedIndex].Value + "! \n";
                if (CheckForTheEmptyDeck()) { }
                //GameOver();
                else
                {
                    foreach (Player opponent in players)
                    {

                        if (opponent.Name != checker.Name)
                        {
                            int temp = opponent.CheckForCards(checker.DeckOfPlayer.cards[selectedIndex]);
                            if (temp != 0)
                            {
                                hasDeal = true;
                                gameWindow.Text += opponent.Name + " oddał " + temp + " kart \n";
                                checker.GiveCards(opponent, selectedIndex, deck);
                                if (opponent.DeckOfPlayer.Count == 0)
                                {
                                    gameWindow.Text += opponent.Name + " ma 0 kart, musi dobrać! \n";
                                    StartCards(opponent.DeckOfPlayer);
                                }
                            }
                        }
                    }
                }
                if (!hasDeal)
                {
                    gameWindow.Text += " nikt nie miał takiej karty! \n";
                    GibCardFromMainDeck(checker);
                }
                
                CheckGroups(checker, groups);
                //showOpCards();
            }
        }

        private void GameOver()
        {
            gibCardButton.IsEnabled = false;
            int temp = 0;
            string winner = "";
            foreach(Player player in players)
            {
                if (player.groupsOfThisPlayer > temp)
                {
                    temp = player.groupsOfThisPlayer;
                    winner = player.Name;
                }
            }
            MessageBox.Show("Koniec gry! Wygrywa - " + winner);
        }

        private void GibCardFromMainDeck(Player player)
        {
            int temp = rand.Next(deck.Count);
            player.DeckOfPlayer.Add(deck.cards[temp]);
            deck.cards.RemoveAt(temp);
        }

        public void Start(string name)
        {
            players.Add(GenerateOpponent(name));
            players.Add(GenerateOpponent("Zbychu"));
            players.Add(GenerateOpponent("Jacek"));
            //showOpCards();
        }

        public async void GameLoop(ListBox hand)
        {
            tcs = new TaskCompletionSource<bool>();
            await tcs.Task;
            while (gibCardButton.IsEnabled)
            {
                foreach (Player player in players)
                {
                    if (player.Name != GetPlayer().Name && player.DeckOfPlayer.Count != 0)
                    {
                        
                        Checker(player, rand.Next(player.DeckOfPlayer.Count));
                        player.DeckOfPlayer.Sort();
                    }
                    else if(player.DeckOfPlayer.Count == 0)
                    {
                        GameOver();
                    }
                    else
                    {
                        player.DeckOfPlayer.Sort();
                        RefreshHand(hand, player);
                        tcs = new TaskCompletionSource<bool>();
                        await tcs.Task;
                    }
                }
            }
            
        }

        public bool CheckForTheEmptyDeck()
        {
            if(deck.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void RefreshHand(ListBox hand, Player player)
        {

            hand.Items.Clear();
            player.DeckOfPlayer.Sort();
            foreach (string card in player.DeckOfPlayer.GetCardNames())
            {
                hand.Items.Add(card);
            }
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
                player.groupsOfThisPlayer++;
            }
            if(player.DeckOfPlayer.Count == 0)
            {
                gameWindow.Text += player.Name + " ma 0 kart, musi dobrać! \n";
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
            for (int i = 0; i < 5; i++)
            {
                if (deck.Count != 0)
                {
                    deck.Shuffle();
                    playersDeck.Add(deck.Deal(rand.Next(deck.Count)));
                }
                else
                    break;
            }
            return playersDeck;
        }
    }
}
