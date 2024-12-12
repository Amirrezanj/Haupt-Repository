namespace _04
{
    internal class Program
    {
        public static int Potenz(int x, int n ,int m=1)
        {
            if (n==0) return m;
            return Potenz(x, n - 1, m * x);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Potenz(2,3));
        }
    }
}