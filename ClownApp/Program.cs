using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownApp
{
    class Program
    {
        interface IClown
        {
            string FunnyThings { get; }
            void Honk();
        }

        interface IScaryClown : IClown
        {
            string ScaryThings { get; }
            void Scare();
        }

        class FunnyFunny : IClown
        {

            public FunnyFunny(string funnyThings)
            {
                this.funnyThings = funnyThings;
            }
            protected string funnyThings;
            public string FunnyThings
            {
                get { return "cześć, mam " + funnyThings; }
            }
            public void Honk()
            {
                Console.WriteLine(this.FunnyThings);
            }
        }

        class ScaryScary : FunnyFunny, IScaryClown
        {
            public ScaryScary(string funnyThing, int numberOfThings):base(funnyThing)
            {
                this.numberOfThings = numberOfThings;
            }
            private int numberOfThings;

            public string ScaryThings
            {
                get { return "Mam " + numberOfThings + " pająków"; }
            }
            public void Scare()
            {
                Console.WriteLine("BNie możesz ,oeć mojego " + base.funnyThings);
            }
        }

        static void Main(string[] args)
        {
            ScaryScary scaryClown = new ScaryScary("duże buty", 35);
            FunnyFunny funnyClown = scaryClown;
            IScaryClown otherScaryClown = funnyClown as ScaryScary;
            otherScaryClown.Honk();
            Console.ReadKey();
        }
    }
}
