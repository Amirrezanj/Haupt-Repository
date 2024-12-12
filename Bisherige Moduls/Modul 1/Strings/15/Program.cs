using System;

namespace _15
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hi, write a string without spaces:");
            string eingabe = Console.ReadLine();

            for (int i = 1; i < eingabe.Length; i++)
            {
                if (char.IsUpper(eingabe[i]))
                {
                    eingabe = eingabe.Insert(i, " ");
                    i++;
                }
                string[] eingabe2 = eingabe.Split(' ');
            }

            Console.WriteLine("Bearbeiteter String: " + eingabe);
        }
    }
}