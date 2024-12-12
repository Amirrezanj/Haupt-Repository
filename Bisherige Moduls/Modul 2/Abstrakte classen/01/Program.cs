namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hund hund = new Hund();
            Console.WriteLine(hund.Ausgabe()); 

            Katze katze = new Katze();
            Console.WriteLine(katze.Ausgabe()); 

            Kuh kuh = new Kuh();
            Console.WriteLine(kuh.Ausgabe());
        }
    }
    public abstract class Tier
    {
        public abstract string Ausgabe();
    }
    public class Katze : Tier
    {
        public override string Ausgabe()
        {
            return "miuuu";
        }
    }
    public class Hund : Tier
    {
        public override string Ausgabe()
        {
            return "hap hap";
        }
    }
    public class Kuh : Tier
    {
        public override string Ausgabe()
        {
            return "muuuuh";
        }
    }
}
