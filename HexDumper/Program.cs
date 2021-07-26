using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexDumper
{
    class Program
    {
        static void Main(string[] args)
        {
            // program do uzycia poprzez cmd
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Sposób uzycia: hexdumper plik-do-wyswietlenia");
            }
            else if (!File.Exists(args[0]))
            {
                Console.Error.WriteLine("Plik nie istnieje: {0}", args[0]);
                Environment.Exit(2);
            }
            else if (args.Length == 1) {
                using (Stream input = File.OpenRead(args[0]))
                {
                    int position = 0;
                    byte[] buffer = new byte[16];
                    while (position < input.Length)
                    {
                        int charactersRead = input.Read(buffer, 0, buffer.Length);
                        if (charactersRead > 0)
                        {
                            Console.Write("{0}: ", String.Format("{0:x4}", position));
                            position += charactersRead;

                            for (int i = 0; i < 16; i++)
                            {
                                if (i < charactersRead)
                                {
                                    string hex = String.Format("{0:x2}", (byte)buffer[i]);
                                    Console.Write(hex + " ");
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                                if (i == 7)
                                {
                                    Console.Write("-- ");
                                }
                                if (buffer[i] < 32 || buffer[i] > 250)
                                {
                                    buffer[i] = (byte)'.';
                                }
                            }
                            string bufferContents = Encoding.UTF8.GetString(buffer);
                            Console.WriteLine(" " + bufferContents.Substring(0, charactersRead));
                        }
                    }
                }
            }
        }
    }
}
