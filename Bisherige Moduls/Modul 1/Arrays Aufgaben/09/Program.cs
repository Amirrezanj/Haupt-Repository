namespace _09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] zahlen= {1,2,3,4,5,6} ;
            for (int i = zahlen.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(zahlen[i]);
            }
        }
    }
}
