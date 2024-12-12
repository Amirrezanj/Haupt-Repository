using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _18
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hi schreib mal ein positiven zahl");
            string eingabetext = Console.ReadLine();
            bool eingabevalid = int.TryParse(eingabetext, out int eingabe);

            if (eingabevalid)
            {
                if (eingabe > 0)
                {
                    double sqrt = Math.Sqrt(eingabe);
                    Console.WriteLine($"original zahl ist {eingabe} und würzel davon ist {sqrt:N2}");
                }
                else
                {
                    Console.WriteLine("negative zahlen gehen nicht");
                }
            }
            else
            {
                Console.WriteLine("falsche eingabe(nur zahl)");
            }
        }
    }
}