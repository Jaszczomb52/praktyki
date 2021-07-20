using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    public class DuckComparerBySize : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Size < y.Size)
                return -1;
            if (x.Size > y.Size)
                return 1;
            return 0;
        }
    }

    public class DuckComparerByKind :IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Kind < y.Kind)
                return -1;
            if (x.Kind > y.Kind)
                return 1;
            else
                return 0;
        }
    }

    public class Duck : IComparable<Duck>
    {
        public int Size;
        public KindOfDuck Kind;

        public int CompareTo(Duck duckToCompare)
        {
            if (this.Size > duckToCompare.Size)
                return 1;
            else if (this.Size < duckToCompare.Size)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return Size + "-centrymetrowa kaczka " + Kind.ToString();
        }
    }

    public enum KindOfDuck
    {
        Mallard,
        Muscovy,
        Decoy
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>()
            {
                new Duck() {Kind = KindOfDuck.Muscovy, Size = 17},
                new Duck() {Kind = KindOfDuck.Mallard, Size = 21},
                new Duck() {Kind = KindOfDuck.Decoy, Size = 19},
                new Duck() {Kind = KindOfDuck.Mallard, Size = 20},
                new Duck() {Kind = KindOfDuck.Decoy, Size = 23},
                new Duck() {Kind = KindOfDuck.Mallard, Size = 18}
            };
            PrintDucks(ducks);
            ducks.Sort();
            PrintDucks(ducks);
            DuckComparerByKind kindComparer = new DuckComparerByKind();
            ducks.Sort(kindComparer);
            PrintDucks(ducks);
            Console.ReadKey();
        }
        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
            {
                Console.WriteLine(duck);
            }
            Console.WriteLine("Koniec kaczek!");
        }

        
    }
}
