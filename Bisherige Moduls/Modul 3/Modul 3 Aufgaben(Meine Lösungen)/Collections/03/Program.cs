namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int x = stack.Peek();
            int y = stack.Pop();

            Console.WriteLine(x);
            Console.WriteLine(y);

        }
    }
}


























using System;
using System.Collections.Generic;

namespace ExpressionValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie einen mathematischen Ausdruck ein:");
            string input = Console.ReadLine();

            if (IstKorrektGeklammert(input))
            {
                Console.WriteLine("Der Ausdruck ist korrekt geklammert.");
            }
            else
            {
                Console.WriteLine("Der Ausdruck ist NICHT korrekt geklammert.");
            }
        }

        static bool IstKorrektGeklammert(string ausdruck)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char zeichen in ausdruck)
            {
                if (zeichen == '(' || zeichen == '[' || zeichen == '{')
                {
                    stack.Push(zeichen);
                }
                else if (zeichen == ')' || zeichen == ']' || zeichen == '}')
                {
                    if (stack.Count == 0)
                        return false;

                    char obereKlammer = stack.Pop();
                    if (!PassenKlammern(obereKlammer, zeichen)) // Klammern passen nicht zusammen
                        return false;
                }
            }

            // Stack muss leer sein, damit alle Klammern geschlossen sind
            return stack.Count == 0;
        }

        static bool PassenKlammern(char öffnende, char schließende)
        {
            return (öffnende == '(' && schließende == ')') ||
                   (öffnende == '[' && schließende == ']') ||
                   (öffnende == '{' && schließende == '}');
        }
    }
}
