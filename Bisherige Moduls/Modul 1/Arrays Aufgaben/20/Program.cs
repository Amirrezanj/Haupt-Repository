namespace _20
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            int[,] zahlen =
                {
                {1, 2, 3 },
                {2, 4, 6 }
                };
            int[,] nachzahlen = new int[3, 2];

            for (int i = 0; i < zahlen.GetLength(0); i++)
            {
                for (int j = 0; j < zahlen.GetLength(1); j++)
                {
                    nachzahlen[j, i] = zahlen[i, j];

                }
            }
            Console.WriteLine("neue form :");
            for (int i = 0; i < nachzahlen.GetLength(0); i++)
            {
                for (int j = 0; j < nachzahlen.GetLength(1); j++)
                {
                    Console.Write(nachzahlen[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}