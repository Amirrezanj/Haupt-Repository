namespace Aufgabe_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int summe = 0;

            for (int zahl = 1; zahl <= 100; zahl++)
            {
                summe += zahl;
                // sum = sum + zahl
            }
            Console.WriteLine(summe);
        }
    }
}
