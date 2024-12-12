using System.Runtime.CompilerServices;
using _01.Extensions;

namespace _01
{
    // Alle 3 Aufgaben sind Dabei
    internal class Program
    {
        static void Main(string[] args)
        {
            string erste = "ott";
            if (erste.IsPalindrom())
            {
                Console.WriteLine("is p");
            }
            else
            {
                Console.WriteLine("is nicht");
            }
            Console.WriteLine(erste.Umgekehrt());


            string[] amir = { "nj", "njj" };
            for (int i = 0; i < amir.Length; i++)
            {
                Console.WriteLine(amir[i]);
            }



            Func<string> liefereGruss = () => "Hallo, Welt!";
            Console.WriteLine(liefereGruss()); // Ausgabe: Hallo, Welt!

        }

    }
}
