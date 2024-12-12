namespace _19
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[,] zahlen =
                {
                { 1, 2, 3, 4, 5 },
                { 2, 3, 4, 5, 6 },
                { 3, 4, 5, 6 ,7 }
                };
            int summe = 0;
            Console.WriteLine("summe alle elemente");
            for (int i = 0; i < zahlen.GetLength(0); i++)
            {
                for (int j = 0; j < zahlen.GetLength(1); j++)
                {
                    summe += zahlen[i, j];
                }
            }
            Console.WriteLine(summe);
        }
    }
}