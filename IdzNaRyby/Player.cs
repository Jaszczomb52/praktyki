using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdzNaRyby
{
    class Player
    {
        public Deck deckOfPlayer { get; set; }
        public string Name { get; private set; }
        public Player(Deck deck, string name)
        {
            deckOfPlayer = deck;
            Name = name;
        }

        public void GiveCards(List<Player> players, int cardIndex)
        {
            Card card = deckOfPlayer.cards[cardIndex];
            for (int j = 0; j < 2; j++)
            {
                if (players.IndexOf(new Player(this.deckOfPlayer, Name)) == j) { }
                else
                {
                    for (int i = 0; i < players[j].deckOfPlayer.Count; i++)
                    {
                    repeat:
                        if (players[j].deckOfPlayer.Check(card))
                        {
                            if (players[j].deckOfPlayer.cards[i].Value == card.Value)
                            {
                                deckOfPlayer.Add(players[j].deckOfPlayer.Deal(i));
                                goto repeat;
                            }
                        }
                    }
                }
            }
        }

        private int ReturnIndex(Card card)
        {
            for(int i = 0; i<deckOfPlayer.Count; i++)
            {
                if(card.ToString() == deckOfPlayer.cards[i].ToString())
                {
                    return i;
                }
            }
            return -1;
        }

        public int CheckForCards(Card cardToCheck)
        {
            int number = 0;
            
            for(int i = 0; i < deckOfPlayer.Count;i++)
            {
                Card card = deckOfPlayer.cards[i];
                if (cardToCheck == card)
                {
                    number++;
                }
            }
            return number;
        }

        public Card[] checkForGroups()
        {
            Card[] group = new Card[4];
            Card recentCard;
            int temp = 1;
            group[0] = deckOfPlayer.cards[0];
            for(int i = 1; i<deckOfPlayer.Count;i++)
            {
                recentCard = deckOfPlayer.cards[i];
                if (recentCard.Value == group[0].Value)
                {
                    group[temp] = recentCard;
                    if(temp == 3)
                    {
                        for(int j = 0; j < 4; j++)
                        {
                            if(ReturnIndex(group[0+j]) != -1)
                            deckOfPlayer.Deal(ReturnIndex(group[0+j]));
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
