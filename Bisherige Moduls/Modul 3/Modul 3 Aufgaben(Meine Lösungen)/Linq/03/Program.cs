namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2,0,  22, 12, 16, 18, 11, 19, 13 };

            //1
            int sumarray= numbers.Sum();
            Console.WriteLine(sumarray);
            Console.WriteLine();

            //2
            int min=numbers.Min();
            Console.WriteLine(min);
            Console.WriteLine();

            //3
            int max=numbers.Max();
            Console.WriteLine(max);
            Console.WriteLine();

            //4
            double avr= numbers.Average();
            Console.WriteLine(avr);
            Console.WriteLine();

            //5
            var mingerade= numbers.Where(x=>x%2==0 && x!=0).Min();
            Console.WriteLine(mingerade);
            Console.WriteLine("");
            
            //6
            var bigungerade=numbers.Where(x=>x %2!=0 && x!=0).Max();
            Console.WriteLine(bigungerade);
            Console.WriteLine();

            //7
            var sumg= numbers.Where(x=>x % 2==0).Sum();
            Console.WriteLine(sumg);
            Console.WriteLine();

            //8 
            var avgung= numbers.Where(x=>x%2!=0).Average();
            Console.WriteLine(avgung);
            Console.WriteLine();
        }
    }
}
