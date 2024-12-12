namespace _02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Angestellte angestellte1 = new Angestellte("amir", "jafari", 55, Tarifgruppe.A);
            Console.WriteLine(angestellte1.GehaltBerechnen());

            Externe externefaraz = new Externe("reza", "nj", 10);
            Console.WriteLine(externefaraz.GehaltBerechnung());

            Externe externeamir = new Externe("amir", "faraz",20);
            Console.WriteLine(externeamir.GehaltBerechnung());


            Praktikant praktikant1 = new Praktikant("sara", "sr", Praktikum.vertrieb);
            Praktikant praktikant2 = new Praktikant("mamad", "md", Praktikum.entwicklung);
            Praktikant praktikant3 = new Praktikant("bahar", "atish", Praktikum.production);

            Console.WriteLine(praktikant1.Gehaltberechnung());
            Console.WriteLine(praktikant2.Gehaltberechnung());
            Console.WriteLine(praktikant3.Gehaltberechnung());

        }
    }

    public class Mitarbeiter
    {
        protected string _vorname;
        protected string _nachname;

        public Mitarbeiter(string vorname, string nachname)
        {
            _nachname = nachname;
            _vorname = vorname;
        }
    }

    public class Angestellte : Mitarbeiter
    {
        private double _angestellteGehalt;
        private double _alter;
        private Tarifgruppe _tarifgruppe;

        public Angestellte(string vorname, string nachname, double alter, Tarifgruppe tarifgruppe) : base(vorname, nachname)
        {
            _alter = alter;
            _tarifgruppe = tarifgruppe; 
        }
        public double GehaltBerechnen()
        {
            double tarif = (double)_tarifgruppe;
            _angestellteGehalt = tarif * (1 + (_alter - 25) / 100);
            return _angestellteGehalt;
        }
    }

    public class Externe : Mitarbeiter
    {
        private int _arbeitstunde;

        public Externe(string vorname, string nachname, int arbeitsstunde) : base(vorname, nachname)
        {
            _arbeitstunde = arbeitsstunde;
        }

        public int GehaltBerechnung()
        {
            int gehalt = _arbeitstunde * 75;
            return gehalt;
        }
    }

    public class Praktikant : Mitarbeiter
    {
        private Praktikum _praktikum;
        private int _gehalt;

        public Praktikant(string vorname, string nachname, Praktikum parktikum) : base(vorname, nachname)
        {
            _praktikum = parktikum;
        }
        public int Gehaltberechnung()
        {
            if (_praktikum == Praktikum.vertrieb)
            {
                _gehalt = 820;
                return _gehalt;
            }
            else if (_praktikum == Praktikum.entwicklung)
            {
                _gehalt = 935;
                return _gehalt;
            }
            else
            {
                _gehalt = 710;
                return _gehalt;
            }
        }
    }

    public enum Tarifgruppe
    {
        A = 2560,
        B = 3000,
        C = 3200,
        D = 5400
    }

    public enum Praktikum
    {
        entwicklung,
        vertrieb,
        production
    }
}