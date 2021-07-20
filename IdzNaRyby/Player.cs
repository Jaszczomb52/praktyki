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


    }
}
