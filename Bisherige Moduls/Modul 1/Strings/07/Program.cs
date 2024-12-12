namespace _07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("erste wort");
            string eingabe1=Console.ReadLine();
            eingabe1 = eingabe1.Trim();

            Console.WriteLine("zweite wort");
            string eingabe2=Console.ReadLine();
            eingabe2 = eingabe2.Trim();

            Console.WriteLine("jetzt ein satzt");
            string zeichenkette=Console.ReadLine();
            zeichenkette = zeichenkette.Trim();

            int index = zeichenkette.IndexOf(eingabe1);
            zeichenkette = zeichenkette.Remove(index, eingabe1.Length);
            zeichenkette = zeichenkette.Insert(index, eingabe2);
            Console.WriteLine(zeichenkette);

        }
    }
}





















