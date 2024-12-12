namespace Aufgabe23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i < 101; i++) 
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write(i);
                    Console.WriteLine(" FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.Write(i);
                    Console.WriteLine(" Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.Write(i);
                    Console.WriteLine(" Buzz");
                }
                else 
                {
                    Console.Write(i);
                    Console.WriteLine("  X");
                }
                
            }
            
        }
    }
}

