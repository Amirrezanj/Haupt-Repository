namespace _02
{
    internal class Program
    {
         public static int Fibonacci(int n)
        {
            //////entweder////////
            if(n== 0) return 0;
            if (n == 1) return 1;
            else return Fibonacci(n - 1) + Fibonacci(n - 2);

            /////oder//////
            //if (n <= 1)
            //    return n;

                //return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("ersten 30 Fibonacci zahlen : ");
           

            for (int i = 0; i < 30; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }
            Console.WriteLine();
        }
    }
}