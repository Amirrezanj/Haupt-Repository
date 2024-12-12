namespace _21
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[,] zahlen =
            {
                {1,2,3 },
                {2,3,4 },
                {3,4,5 }
            };
            for (int i = 0; i < zahlen.GetLength(0); i++)
            {
                Console.Write(zahlen[i,i]+" ");
            }
            
        }
    }
}