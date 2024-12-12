namespace Aufgabe17
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Random random = new System.Random();
            int number1 = random.Next(1, 101);
            int number2 = random.Next(1, 101);
            int summ = number1 + number2;
            Console.WriteLine("hi after Enter knopft zeige ich dir zufälige zahlen .");
            Console.ReadKey();
            Console.WriteLine(number1 + "  ,  " + number2);
            Console.WriteLine("enter to continue");
            
            //ConsoleKeyInfo keyInfo = Console.ReadKey();
            //if(keyInfo.Key == ConsoleKey.Enter)
            //{

            //}

            Console.WriteLine("try to add Nummbers and give me your antwort");
            string numbergiveText = Console.ReadLine();
            int numbergive = 0;
            int.TryParse(numbergiveText, out numbergive);
            if (numbergive == summ)
            {
                Console.WriteLine("perfect hast du gut gemacht");
            }
            else
            {
                Console.WriteLine("falsch");
            }
        }
    }
}