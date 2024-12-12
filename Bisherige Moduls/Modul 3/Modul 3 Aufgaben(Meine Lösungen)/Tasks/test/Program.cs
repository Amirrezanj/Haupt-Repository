namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] zahlen = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine(zahlen[0,0]);
            Console.WriteLine(zahlen[0,1]);
            Console.WriteLine(zahlen[0,2]);
            Console.WriteLine(zahlen[1,0]);
            Console.WriteLine(zahlen[1,1]);
            Console.WriteLine(zahlen[1,2]);
            Console.WriteLine(zahlen[2,0]);
            Console.WriteLine(zahlen[2,1]);
            Console.WriteLine(zahlen[2,2]);
        }
    }
}
