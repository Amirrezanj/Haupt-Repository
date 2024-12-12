namespace Aufgabe_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("write your Number");
            string EingabeText = Console.ReadLine();
            int Eingabe = 0;
            int.TryParse(EingabeText, out Eingabe);

            for (int i =1; i <= 10; i++)
            {
                Console.WriteLine(Eingabe+" X " +i+" = "+Eingabe*i);
            };
        }
    }
}
