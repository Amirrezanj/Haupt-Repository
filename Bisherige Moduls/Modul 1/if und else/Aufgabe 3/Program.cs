namespace Aufgabe_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("hey You , please write your age");
            string AgeText = Console.ReadLine();

            int Age = 0;
            int.TryParse(AgeText, out Age);

            if (Age >= 0 && Age <= 12)
            {
                Console.WriteLine("Kinder Groupe");
            }
            else if (Age >= 13 && Age <= 19)
            {
                Console.WriteLine("Jugendlische Gruppe");
            }
            else if (Age >= 20 && Age <= 59)
            {
                Console.WriteLine("Erwachsene");
            }
            else if (Age >= 60)
            {
                Console.WriteLine("Senioren");
            }
            else
            {
                Console.WriteLine("Falche Eingabe");
            }
            
        }
    }
}