namespace Aufgabe24_kreditkarte_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(" geben Sie ihre Kreditkart  nummer ein");
            int kreditkarte_nummer = int.Parse(Console.ReadLine());
            int stelle_verdoppelt = 1;
            int summe = 0;

            while (kreditkarte_nummer > 0)
            {
                int stelle_prufer = kreditkarte_nummer % 10;
                kreditkarte_nummer = kreditkarte_nummer / 10;

                if (stelle_verdoppelt % 2 == 0)
                {
                    stelle_prufer = stelle_prufer * 2;
                    if (stelle_prufer > 9)
                    {
                        stelle_prufer = stelle_prufer - 9;
                    }
                }

                summe = summe + stelle_prufer;
                stelle_verdoppelt++;
            }
            if (summe % 10 == 0)
            {
                Console.WriteLine(" Die kredit Kart nummer ist richtig");
            }
            else
                Console.WriteLine(" falsch Nummer");
        }
    }
}
    
