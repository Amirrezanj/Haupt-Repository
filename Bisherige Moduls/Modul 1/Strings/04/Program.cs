namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geben Sie Zeichenkette ein: ");
            string eingabe = Console.ReadLine();

            string bearbeitet = eingabe.Replace(" ", "");
            Console.WriteLine("normale version "+eingabe);
            Console.WriteLine("bearbeitete version " + bearbeitet);
        }
    }
}