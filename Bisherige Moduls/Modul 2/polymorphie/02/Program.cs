using _02.Models;

namespace _02
{
    internal class Program
    {
        private static Haustier[] _haustiere = new Haustier[6];

        private static void Main(string[] args)
        {
            HaustiereAnlegen();
            ((Katze)_haustiere[2]).SetLieblingsvogel((Vogel)_haustiere[1]);
            Ausgeben();
            SetNeuerLieblingsvogel((Katze)_haustiere[2], (Vogel)_haustiere[4]);
            Ausgeben();
            
        }

        public static void HaustiereAnlegen()
        {
            _haustiere[0] = new Hund("bili", 500, "chihuhua");
            _haustiere[1] = new Vogel("jesi", 200, "blablabla");
            _haustiere[2] = new Katze("wedensday", 300, (Vogel)_haustiere[1]);
            _haustiere[3] = new Hund("tomi", 500, "golden retriver");
            _haustiere[4] = new Vogel("chikchik", 220, "bluuuubluuu");
            _haustiere[5] = new Katze("malos", 310, (Vogel)_haustiere[4]);
        }

        public static void SetNeuerLieblingsvogel(Katze katze, Vogel vogel)
        {
            if (katze != null && vogel != null)
            {
                katze.SetLieblingsvogel(vogel);
            }
            else
            {
                Console.WriteLine("ist nicht ausgelegt.");
            }
        }

        public static void Ausgeben()
        {
            for (int i = 0; i < _haustiere.Length; i++)
            {
                Console.Write(_haustiere[i].GetType().Name+" ");
                Console.WriteLine(_haustiere[i].GetBeschreibung());
                Console.Write("jahreskosten:");
                Console.Write(_haustiere[i].GetJahresKosten());
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}