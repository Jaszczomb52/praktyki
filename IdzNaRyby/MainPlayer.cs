using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdzNaRyby
{
    class MainPlayer: Player 
    {
        public MainPlayer(Deck deck, string name):base(deck, name)
        {

        }

        // tu se beda metody tylko dla glownego gracza (osoba grajaca)
    }
}
