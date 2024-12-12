namespace Aufgabe20
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = 30;  
            int a = 0;   
            int b = 1;
            //nur für while schleife
            //int i = 1;
            

            Console.WriteLine("Die ersten 30 Fibonacci Zahlen sind:");

            for (int i = 1; i < n; i++)
            {
                int nextnumber = a + b;
                Console.Write(nextnumber + " ");
                a = b;
                b = nextnumber;
            }

            Console.Write(a + " " + b + " ");

            
            //while (i < n ) 
            //{
            //    int nextnumber = a + b;
            //    Console.Write(nextnumber + " ");
            //    a = b;
            //    b = nextnumber;
            //    i++;
            //}
        }
    }
}