namespace _17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i]=="--foregroundcolor")
                {
                    if (args[i+1]=="rot")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                if (args[i] == "--backgroundcolor")
                {
                    if (args[i + 1] == "blau")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                }
            }
        }
    }
}






















using System;

class Program
{
    static void Main()
    {
        // Erstelle und initialisiere eine 3x3 Matrix
        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        // Ausgabe der Matrix
        Console.WriteLine("3x3 Matrix:");

        int count = 0; // Zähler für Zeilenumbruch
        foreach (int value in matrix)
        {
            Console.Write(value + " ");
            count++;
            if (count % 3 == 0) // Nach jedem dritten Element ein Zeilenumbruch
            {
                Console.WriteLine();
            }
        }
    }
}
