using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BibliothekArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] buch = new string[,]
            {
                {
                    "1",
                    "2",
                    "3"
                },
                {
                    "  1 - Ab. I.       Pitt, der freche Seeräuber (Lesebilderbuch)",
                    "  2 - Ab. I.       Jona und Joni - Abenteuer in der Schule - Bachems erstes Lesen",
                    "Paula ist doch schon groß ! (Lese Spatz)"
                }
            };
            
            Console.WriteLine(buch[0, 0] + " " + buch[1, 0]);

            Console.WriteLine(buch[0, 1] + " " + buch[1, 1]);

            Console.WriteLine(buch[0, 2] + " " + buch[1, 2]);


            Console.ReadKey();
        }
    }
}