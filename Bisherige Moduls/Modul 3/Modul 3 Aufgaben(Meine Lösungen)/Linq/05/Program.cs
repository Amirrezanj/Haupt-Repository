namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = 
            {
                 "zero", "one", "two",
                 "three", "four", "five",
                 "six", "seven", "eight",
                 "nine", "ten", "eleven",
                 "twelve", "thirteen", "fourteen" 
            };
            //1
            var sort1=numbers.OrderBy(x => x.Length);
            foreach (var x in sort1)
            {
                Console.Write($"{x },");
            }
            Console.WriteLine();

            //2
            var sort2 = sort1.ThenByDescending(x => x);
            foreach (var x in sort2)
            {
                Console.Write($"{x},");
            }
            Console.WriteLine();

            //3
            var sort3 = numbers.Reverse();
            foreach (var x in sort3)
            {
                Console.Write($"{x},");

            }

        }
    }
}
