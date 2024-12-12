namespace Aufgabe_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }
}
