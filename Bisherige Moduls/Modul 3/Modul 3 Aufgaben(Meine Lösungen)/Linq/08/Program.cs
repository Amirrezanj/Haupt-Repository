namespace _08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers =
            {
                "zero", "one", "two", "three", "four",
                "five", "six", "seven", "eight",
                "nine", "ten", "eleven", "twelve",
                "thirteen", "fourteen"
            };
            //1
            var groups = numbers.GroupBy(x => x[0]);
            foreach (var group in groups)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            //2
            var groups2= numbers.GroupBy(x => x.Length);
            foreach (var group2 in groups2)
            {
                Console.WriteLine(group2.Key);
                foreach (var item2 in group2)
                {
                    Console.Write($"{item2} ");
                }
                Console.WriteLine();
            }
        }
    }
}