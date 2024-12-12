namespace _08
{
    internal class Program
    {
        public static int ReadNumberFromUser(string message)
        {
            Console.WriteLine(message);
            string eingabeText = Console.ReadLine();
            int.TryParse(eingabeText, out int eingabe);
            return eingabe;
        }
        public static int CalculateProduct(int numberOne, int numberTwo, int numberThree)
        {
            return numberOne * numberTwo * numberThree;
        }

        public static int CalculateSum(int numberOne, int numberTwo, int numberThree)
        {
            return numberOne + numberTwo + numberThree;
        }

        public static void PrintResult(int result , int malresult)
        {
            Console.WriteLine("die summe ist " + result+" und die multiplikation ist "+malresult);
        }

        private static void Main(string[] args)
        {
            int num1 = ReadNumberFromUser("first num: ");
            int num2 = ReadNumberFromUser("second num: ");
            int num3 = ReadNumberFromUser("third num :");
            PrintResult(CalculateSum(num1, num2, num3),CalculateProduct(num1,num2,num3));

        }
    }
}