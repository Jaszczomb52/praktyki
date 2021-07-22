using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdzNaRyby
{
    class Player
    {
        public Deck DeckOfPlayer { get; set; }
        public string Name { get; private set; }
        public int groupsOfThisPlayer = 0;
        public Player(Deck deck, string name)
        {
            DeckOfPlayer = deck;
            Name = name;
        }
        
        public void GiveCards(Player players, int cardIndex, Deck deck)
        {
            Card card = DeckOfPlayer.cards[cardIndex];
            bool deal = false;
            for (int i = 0; i < players.DeckOfPlayer.Count; i++)
            {
            repeat:
                if (players.DeckOfPlayer.Check(card))
                {
                    if (players.DeckOfPlayer.cards[i].Value == card.Value)
                    {
                        DeckOfPlayer.Add(players.DeckOfPlayer.Deal(i));
                        deal = true;
                        goto repeat;
                    }
                }
            }
            
            if(deal == false)
            {
                deck.Shuffle();
                Random rand = new Random();
                DeckOfPlayer.Add(deck.Deal(rand.Next(deck.Count)));
            }
        }

        private int ReturnIndex(Card card)
        {
            for(int i = 0; i<DeckOfPlayer.Count; i++)
            {
                if(card.ToString() == DeckOfPlayer.cards[i].ToString())
                {
                    return i;
                }
            }
            return -1;
        }

        public int CheckForCards(Card cardToCheck)
        {
            int number = 0;
            
            for(int i = 0; i < DeckOfPlayer.Count;i++)
            {
                Card card = DeckOfPlayer.cards[i];
                if (cardToCheck.Value == card.Value)
                {
                    number++;
                }
            }
            return number;
        }

        public Card[] CheckForGroups()
        {
            Card[] group = new Card[4];
            Card recentCard;
            int temp = 1;
            DeckOfPlayer.Sort();
            group[0] = DeckOfPlayer.cards[0];
            for(int i = 1; i<DeckOfPlayer.Count;i++)
            {
                recentCard = DeckOfPlayer.cards[i];
                if (recentCard.Value == group[0].Value)
                {
                    group[temp] = recentCard;
                    if(temp == 3)
                    {
                        for(int j = 0; j < 4; j++)
                        {
                            if(ReturnIndex(group[0+j]) != -1)
                            DeckOfPlayer.Deal(ReturnIndex(group[0+j]));
                        }
                        return group;
                    }
                    temp++;
                }
                else
                {
                    temp = 1;
                    group[0] = recentCard;
                    for (int j = 1; j < 4; j++)
                    {
                        group[j] = null;
                    }
                }
            }
            return group;
        }

    }
}
