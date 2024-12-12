namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };
            //1
            var sort1=numbers.OrderByDescending(x=>x);
            foreach (int x in sort1)
            {
                Console.Write($"{x} ,");
            }
            Console.WriteLine();
            //2
            var sort2=numbers.Order();
            foreach (int x in sort2)
            {
                Console.Write($"{x} ,");

            }
            Console.WriteLine();
            //3
            var gsort= numbers.Where(x=>x%2==0 && x!=0).OrderByDescending(x=>x);
            foreach (int x in gsort)
            {
                Console.Write($"{x} ,");
            }
            Console.WriteLine();


        }
    }
}
