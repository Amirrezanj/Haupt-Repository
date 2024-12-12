using System.Diagnostics.CodeAnalysis;

namespace Aufgabe_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Sum = 0;
            Console.WriteLine("Ungerade zahlen sind");
            for (int i = 1; i <= 100; i++)
            {
                
                if (i % 2 != 0)
                {
                    Sum=Sum+i;
                    Console.Write(i+" ");
                    
                    
                }
                
            }
            Console.WriteLine("\ndie gesamt summe ist   "+Sum);
        }

    }
}
