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

        public void CheckForCards()
        {
            
        }

    }
}
