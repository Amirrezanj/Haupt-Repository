namespace _14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("write a satz") ;

            string eingabe = Console.ReadLine();

            string vokale = "aeiouAEIOU";

            for (int i = 0; i < eingabe.Length; i++)
            {
                if (vokale.IndexOf(eingabe[i]) == -1 && char.IsLetter(eingabe[i]))
                {
                    eingabe = eingabe.Remove(i, 1).Insert(i, "*");
                }
            }

            Console.WriteLine("Ergebnis nach operation " + eingabe);

        }
    }
}







using System;

class Program
{
    static void Main()
    {
        Console.Write("Bitte eine Zeichenkette eingeben: ");
        string eingabe = Console.ReadLine();

        string vokale = "aeiouAEIOU";

        string bearbeitet1 = eingabe;
        for (int i = 0; i < bearbeitet1.Length; i++)
        {
            if (!vokale.Contains(bearbeitet1[i]) && char.IsLetter(bearbeitet1[i]))
            {
                bearbeitet1 = bearbeitet1.Remove(i, 1).Insert(i, "*");
            }
        }

        string bearbeitet2 = eingabe;
        foreach (char c in eingabe)
        {
            if (!vokale.Contains(c) && char.IsLetter(c))
            {
                bearbeitet2 = bearbeitet2.Replace(c.ToString(), "*");
            }
        }

        Console.WriteLine("Ergebnis mit IndexOf, Remove, Insert: " + bearbeitet1);
        Console.WriteLine("Ergebnis mit Replace: " + bearbeitet2);
    }
}
