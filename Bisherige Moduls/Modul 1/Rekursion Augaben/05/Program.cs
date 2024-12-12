namespace _05
{
    internal class Program
    {
        public static int Treppe(int n)
        {
            //if(n<=1)return 1;
            if (n == 0) return 1;
            if (n == 1) return 1;
            return Treppe(n-1)+Treppe(n-2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Treppe(6));
        }
    }
}
