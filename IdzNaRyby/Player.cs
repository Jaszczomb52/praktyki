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

        // sprawdzic czy dziala i sprawdzicy czy jest wgl w stanie dodac kilka kart na raz
        public int CheckForCard(Card card)
        {
            foreach(Card x in deckOfPlayer.cards)
            {
                if(x.Value == card.Value)
                {
                    return deckOfPlayer.cards.IndexOf(x);
                }
            }
            return -1;
        }

    }
}
