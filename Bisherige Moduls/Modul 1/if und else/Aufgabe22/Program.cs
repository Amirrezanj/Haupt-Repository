namespace Aufgabe22
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Random zufall = new System.Random();
            int zufallnumber = zufall.Next(1, 100);
            Console.WriteLine("bitte schätzen sie 1 zahl zwischen 1 und 100");
            string eingabetext = Console.ReadLine();
            int.TryParse(eingabetext, out int eingabe );
            while (eingabe!=zufallnumber)
            {
                Console.Write("falsch geschätzt ");
                if (eingabe > zufallnumber)
                {
                    Console.Write("(zu gross)");
                }
                else
                {
                    Console.Write("(zu klein)");
                }
                eingabetext = Console.ReadLine();
                int.TryParse(eingabetext, out eingabe);

            }
            Console.WriteLine("super");
        }
    }
}