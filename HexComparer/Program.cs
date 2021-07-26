using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HexComparer
{
    class Program
    {
        static void Main()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Random rand = new Random();
            /*using (Stream output = File.Create("C:\\Users\\cmdrb\\documents\\karta1.dat"))
            {
                formatter.Serialize(output, new Card((Suits)rand.Next(0,3), (Values)rand.Next(0,12)));
            }
            using (Stream output = File.Create("C:\\Users\\cmdrb\\documents\\karta2.dat"))
            {
                formatter.Serialize(output, new Card((Suits)rand.Next(0,3),(Values)rand.Next(0,12)));
            }*/
            byte[] firstFile = File.ReadAllBytes("C:\\Users\\cmdrb\\documents\\karta1.dat");
            byte[] secondFile = File.ReadAllBytes("C:\\Users\\cmdrb\\documents\\karta2.dat");
            for(int i = 0;i< firstFile.Length;i++)
                if(firstFile[i] != secondFile[i])
                    Console.WriteLine("Bajt numer {0}: {1} i {2} ", i, firstFile[i], secondFile[i]);
            firstFile[252] = (byte)Suits.Diamonds;
            firstFile[298] = (byte)Values.King;
            File.Delete("C:\\Users\\cmdrb\\documents\\karta3.dat");
            File.WriteAllBytes("C:\\Users\\cmdrb\\documents\\karta3.dat", firstFile);
            using (Stream input = File.OpenRead("C:\\Users\\cmdrb\\documents\\karta3.dat"))
            {
                Card king = (Card)formatter.Deserialize(input);
                Console.Write(king.ToString());
            }
            Console.ReadKey();
        }
    }
}
