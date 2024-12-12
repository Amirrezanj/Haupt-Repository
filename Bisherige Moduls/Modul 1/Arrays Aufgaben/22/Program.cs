namespace _22
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[,,] zahlen =
            {
                { { 1, 2, 3 }, { 2, 3, 4}, { 3, 4, 5} },
                { { 2, 3, 4 }, { 3, 4, 5}, { 4, 5, 6} },
                { { 3, 4, 5 }, { 4, 5, 6}, { 5, 6, 7} }
            };

            for (int i = 0; i < zahlen.GetLength(0); i++)
            {
                for (int j = 0; j < zahlen.GetLength(1); j++)
                {
                    for (int k = 0; k < zahlen.GetLength(2); k++)
                    {
                        Console.Write(zahlen[i,j,k]+" ");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}