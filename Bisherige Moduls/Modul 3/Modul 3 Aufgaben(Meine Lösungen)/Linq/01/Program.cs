namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

            var k7 = numbers.Where(x => x < 7).ToList().Order();
            foreach (var x in k7)
            {
                Console.Write($"{x}, ");
            }
            Console.WriteLine();

            var geradezahlen = numbers.Where(x => x % 2 == 0&& x != 0).Order();
            foreach (var item in geradezahlen)
            {
                Console.Write($"{item },");
            }
            Console.WriteLine();

            var ung1=numbers.Where(x => x % 2 != 0 && x<10).Order();
            foreach (var item in ung1)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();

            var g1=numbers.Skip(5).Where(x => x % 2 == 0 ).ToList();
            foreach (var item in g1)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
        }
    }
}
