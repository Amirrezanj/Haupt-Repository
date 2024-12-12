namespace _01
{
    internal class Program
    {
        public static int Sum(int n)
        {
            if (n == 0) return 0;
            return Sum(n - 1) + n;
        }
        public static int ESum(int n,int resault = 0)
        {
            if (n==0) return resault;
            return ESum(n-1 , n +resault);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Sum(5));
            Console.WriteLine(ESum(5));
        }
    }
}
