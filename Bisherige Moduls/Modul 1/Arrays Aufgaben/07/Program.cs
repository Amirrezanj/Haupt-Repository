using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] zahlen = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            Console.Write("die zahlen sind ");
            for (int i = 0; i < zahlen.Length; i++)
            {
                Console.Write(zahlen[i]+" , ");
            }

            int summe = 0;
            for (int s = 0; s < zahlen.Length; s++)
            {
              summe += zahlen[s] ;
            }
            Console.WriteLine("die summe ist "+summe);



            int durchschnitt = 0;
            for (int d = 0; d < zahlen.Length; d++)
            {
                durchschnitt =summe/zahlen.Length ;
            }
            Console.WriteLine("durchschnit ist "+durchschnitt);



            int varianz = 0;
            int vsumme = 0;
            for (int v = 0; v < zahlen.Length; v++)
            {
                varianz += (zahlen[v]-durchschnitt)*(zahlen[v] - durchschnitt) / (zahlen.Length);
            }
            Console.WriteLine("die varianz ist "+varianz);


            
            Console.WriteLine("die standardabweichung ist "+Math.Sqrt(varianz));

        }
    }
}