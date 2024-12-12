namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vorname = "amirreza";
            string nachname = "nj";
            string komplet = vorname + nachname;

            Console.WriteLine($"vorname ist: {vorname} und hat {vorname.Length} zeichen");
            Console.WriteLine($"nachname ist: {nachname} und hat {nachname.Length} zeichen");
            Console.WriteLine($"Komplete name ist: {komplet} und hat {komplet.Length} zeichen");
        }
    }
}
