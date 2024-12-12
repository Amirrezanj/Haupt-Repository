using System.Security.Cryptography.X509Certificates;

namespace _01
{
    internal class Program
    {
        public static int Add(int a, int b)
        {           
            int summe = a + b;
            return summe;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Add(2,3));
        }
    }
}
