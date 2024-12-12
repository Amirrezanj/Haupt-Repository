namespace Aufgabe_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("write street");
            string street = Console.ReadLine();
            Console.WriteLine("write Haus Nr");
            string hn = Console.ReadLine();
            Console.WriteLine("write stadt");
            string stadt = Console.ReadLine();
            Console.WriteLine("Deine Adresse ist : " + street+ " " + hn + stadt);

        }
    }
}
