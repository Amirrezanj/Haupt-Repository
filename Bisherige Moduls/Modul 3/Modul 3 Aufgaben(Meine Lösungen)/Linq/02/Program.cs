namespace _02
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            string[] numbers =
            {
                   "zero", "one", "two", "three", "four",
                   "five", "six", "seven", "eight", "nine",
                   "ten", "eleven", "twelve", "thirteen", "fourteen"
            };
            //1
            var threechar = numbers.Where(x => x.Length == 3).Order();
            foreach (var item in threechar)
            {
                Console.WriteLine($"{item}, ");
            }
            Console.WriteLine();
            //2
            var haseo = numbers.Where(x => x.Contains("o"));
            foreach (var item in haseo)
            {
                Console.WriteLine($"{item}, ");
            }
            Console.WriteLine();
            //3
            var finishteen = numbers.Where(x => x.EndsWith("teen"));
            foreach (var item in finishteen)
            {
                Console.WriteLine($"{item}, ");
            }
            Console.WriteLine();
            //4
            foreach (var item in finishteen)
            {
                Console.WriteLine(item.ToUpper());
            }
            Console.WriteLine();
            //5
            var withfour = numbers.Where(x => x.Contains("four"));
            foreach (var item in withfour)
            {
                Console.WriteLine(item.ToUpper());
            }


        }
    }
}