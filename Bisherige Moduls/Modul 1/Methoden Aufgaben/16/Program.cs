namespace _16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] zahlen = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int lengthDim0 = zahlen.GetLength(0);
            int lengthDim1 = zahlen.GetLength(1);
            
            Console.WriteLine(lengthDim0);
            Console.WriteLine(lengthDim1);

        }
    }
}