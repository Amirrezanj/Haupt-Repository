namespace Aufgabe_11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please write your Number to chek prime");
            string ZahlText = Console.ReadLine();
            int Zahl = 0;
            int.TryParse(ZahlText, out Zahl);


            bool istprim = true;
            for (int i = 2; i < Zahl; i++)
            {
                if (Zahl % i == 0)
                {
                    istprim = false;
                }
            }
            if (istprim == true)

            {
                Console.WriteLine("es ist primzahl");
            }
            else
            {
                Console.WriteLine("it wasnt Prime");
            }
        }
    }
}