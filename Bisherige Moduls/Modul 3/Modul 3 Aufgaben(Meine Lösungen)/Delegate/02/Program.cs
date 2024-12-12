namespace _02
{
    public delegate bool VergleichsHandler(int x,int y);
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1,100);
                Console.Write(arr[i]+" ");
            }
            GetLimit(IstGrößer, arr);
            GetLimit(IstKleiner, arr);

            Console.WriteLine();
            Console.WriteLine(GetLimit(IstGrößer, arr));
            Console.WriteLine(GetLimit(IstKleiner, arr));
        }
        private static int GetLimit(VergleichsHandler vergleichsHandler, int[] zahlen)
        {
            int größte = zahlen[0];
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (vergleichsHandler(zahlen[i], größte))
                {
                    größte = zahlen[i];
                }
            }
            return größte;
        }
        private static bool IstKleiner(int x, int y)
        {
            return x < y;
        }
        private static bool IstGrößer(int x, int y)
        {
            return x > y;
        }
    }
}