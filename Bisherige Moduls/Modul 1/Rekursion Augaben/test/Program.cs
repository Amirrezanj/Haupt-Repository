using System;

class Program
{
    static void Main()
    {
        string[] geschenke = { "Geschenk 1", "Geschenk 2", "Geschenk 3", "Geschenk 4", "Geschenk 5" };
        double[] wahrscheinlichkeiten = { 0.35, 0.30, 0.20, 0.10, 0.05 };

        string heutigesGeschenk = ZieheGeschenk(geschenke, wahrscheinlichkeiten);
        Console.WriteLine("Das heutige Geschenk ist: " + heutigesGeschenk);
    }

    static string ZieheGeschenk(string[] geschenke, double[] wahrscheinlichkeiten)
    {
        Random rand = new Random();
        double zufall = rand.NextDouble();
        double kumulierteWahrscheinlichkeit = 0.0;

        for (int i = 0; i < geschenke.Length; i++)
        {
            kumulierteWahrscheinlichkeit += wahrscheinlichkeiten[i];
            if (zufall < kumulierteWahrscheinlichkeit)
            {
                return geschenke[i];
            }
        }

        // Falls keine Übereinstimmung gefunden wird (was theoretisch nicht passieren sollte)
        return geschenke[geschenke.Length - 1];
    }
}
