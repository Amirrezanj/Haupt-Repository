namespace _05
{
    internal class Program
    {
        public static bool IsEven(int number)
        {
            
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("write a number to chek gerade oder ungerade");
            int number = int.Parse(Console.ReadLine());
            if (IsEven(number))
            {
                Console.WriteLine("gerade");
            }
            else
            {
                Console.WriteLine("ungearde");
            }

        }
    }
}
