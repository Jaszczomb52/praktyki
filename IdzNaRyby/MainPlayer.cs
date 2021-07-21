using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IdzNaRyby
{
    class MainPlayer: Player 
    {
        public MainPlayer(Deck deck, string name):base(deck, name)
        {

        }

        // tu se beda metody tylko dla glownego gracza (osoba grajaca)

        public void RefreshHand(ListBox hand)
        {

            hand.Items.Clear();
            deckOfPlayer.Sort();
            foreach (string card in deckOfPlayer.GetCardNames())
            {
                hand.Items.Add(card);
            }
        }
    }
}
