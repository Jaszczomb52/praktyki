using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deck
{
    public class Card : IComparable<Card>
    {
        public Suits Suit { get; set; }
        public Values Value { get; set; }
        
        public int CompareTo(Card compare)
        {
            if (this.Value > compare.Value)
                return 1;
            else if (this.Value < compare.Value)
                return -1;
            else
                return 0;
        }

        public Card(Suits Suit, Values Value)
        {
            this.Suit = Suit;
            this.Value = Value;
        }
        public string Name
        {
            get
            {
                return Value.ToString() + " of " + Suit.ToString();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class CardComparer : IComparer<Card>
    {
        public SortCriteria SortBy = SortCriteria.Value;
        public int Compare(Card x, Card y)
        {
            if(SortBy == SortCriteria.Value)
            {
                if (x.Value > y.Value)
                    return 1;
                else if (x.Value < y.Value)
                    return -1;
                else
                    return 0;
            }
            else
            {
                if (x.Suit > y.Suit)
                    return 1;
                else if (x.Suit < y.Suit)
                    return -1;
                else
                    return 0;
            }
        }
    }

    public enum SortCriteria
    {
        Value,
        Suit,
    }


    public enum Suits
    {
        Spades,
        Clubs,
        Diamonds,
        Hearts,
    }
    public enum Values
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
}
