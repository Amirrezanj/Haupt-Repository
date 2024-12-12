using System.Net.Quic;

namespace Aufgabe26
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //nach zahl 1 fragen
            string jaein = "0";
            while (jaein != "quit")
            {
                Console.WriteLine("First Nummber : ");
                string eingabe1text = Console.ReadLine();
                int.TryParse(eingabe1text, out int eingabe1);

                //nach opertaion fragen
                Console.WriteLine("welche Operation?( + , - , * , / )");
                string operation = Console.ReadLine();

                //nach zweite zahl fragen
                Console.WriteLine("and now second nummber");
                string eingabe2text = Console.ReadLine();
                int.TryParse(eingabe2text, out int eingabe2);
                //mathematisch
                if (operation == "+")
                {
                    int sum = eingabe1 + eingabe2;
                    Console.WriteLine("the answer is " + sum);
                }
                else if (operation == "-")
                {
                    int min = eingabe1 - eingabe2;
                    Console.WriteLine("the answer is " + min);
                }
                else if (operation == "*")
                {
                    int mal = eingabe1 * eingabe2;
                    Console.WriteLine("the answer is " + mal);
                }
                else if (operation == "/")
                {
                    int durch = eingabe1 / eingabe2;
                    Console.WriteLine($"the answer is {durch}");
                }

                //weiter
                Console.WriteLine("do you want to continiue? if yes from( 0 ) or from the (lastanswer) or dou you want to (quit)?");
                jaein = Console.ReadLine();

                if (jaein == "0")
                {
                    eingabe1 = 0;
                    eingabe2 = 0;
                    
                }
                else if (jaein == "lastanswer")
                {
                    int lastanswer = 0;
                    lastanswer = eingabe1;
                }
                else if (jaein == "quit")
                {
                    break;
                }
            }
        }
    }
}