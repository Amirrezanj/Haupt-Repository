namespace Aufgabe_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //ask a Input(nummber)
            Console.WriteLine("hi u . please write your age");
            string AgeText = Console.ReadLine();

            //change Input in Integer
            int Age = 0;
            bool AgeTextvalid = int.TryParse(AgeText, out Age);

            if (AgeTextvalid)
            {
                //check number > 18 ?
                if (Age > 18)
                {
                    Console.WriteLine("u are erwachsene");
                }
                else
                {
                    Console.WriteLine("u are small :)");
                }
            }
            else
            {
                Console.WriteLine("falsche eingabe");
            }
        }
    }
}