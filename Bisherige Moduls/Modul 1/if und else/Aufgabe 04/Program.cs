using System;

namespace Aufgabe_04
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hi pl write me 3 Numbers");

            Console.WriteLine("write first Number");
            string Num1text = Console.ReadLine();
            int Num1 = 0;
            int.TryParse(Num1text, out Num1);

            Console.WriteLine("now second Number");
            string Num2Text = Console.ReadLine();
            int Num2 = 0;
            int.TryParse(Num2Text, out Num2);

            Console.WriteLine("write last one");
            string Num3Text = Console.ReadLine();
            int Num3 = 0;
            int.TryParse(Num3Text, out Num3);


            if 

            if (Num1 > Num2)
            {
                if (Num1 > Num3)
                {
                    Console.WriteLine("the biggest Nummber is " + Num1);
                }
                else
                {
                    Console.WriteLine("the biggest Nummber is " + Num3);
                }
            }
            else if (Num2 > Num1)
            {
                if (Num2 > Num3)
                {
                    Console.WriteLine("the biggest Nummber is " + Num2);
                }
                else
                {
                    Console.WriteLine("the biggest Nummber is " + Num3);
                }
            }
            else
            {
                Console.WriteLine("falsche eingabe");
            }
        }
    }
}