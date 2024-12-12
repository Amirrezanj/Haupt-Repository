namespace _08
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] zahlen = { 0, 1, 2, 3, 4, 5, 6, 7, 80, 9 };
            int min = zahlen[0];
            int max = zahlen[0];
            Console.WriteLine("zahlen sind : ");
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] < min)
                {
                    min = zahlen[i];
                }
                else if (zahlen[i] > max)
                {
                    max = zahlen[i];
                }
            Console.WriteLine(zahlen[i]);
            }
            Console.WriteLine("max Nummer ist " + max);
            Console.WriteLine("Min Nummer ist " + min);
        }
    }
}