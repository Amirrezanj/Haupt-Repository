namespace a_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("pl give me Länge");
            string LängeString = Console.ReadLine();
            Console.WriteLine("now give me Bereite");
            string BereiteString = Console.ReadLine();
            int LängeInt = int.Parse(LängeString);
            int BereiteInt = int.Parse(BereiteString);
            int FlächenInhalt = BereiteInt * LängeInt;
            Console.WriteLine(FlächenInhalt);
        }
    }
}
