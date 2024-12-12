namespace _02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Erstellen und Testen der verschiedenen Mitarbeiter
            Angestellte angestellte1 = new Angestellte("Homer", "Simpson", Tarifgruppe.A, 40);
            angestellte1.GehaltBerechnen();
            angestellte1.Ausgabe();

            Externe externe1 = new Externe("Lenny", "Leonard", 160);
            externe1.GehaltBerechnen();
            externe1.Ausgabe();

            Praktikant praktikant1 = new Praktikant("Bart", "Simpson", "Vertrieb");
            praktikant1.GehaltBerechnen();
            praktikant1.Ausgabe();
        }
    }

    // Basisklasse für Mitarbeiter
    public class Mitarbeiter
    {
        protected string _vorname;
        protected string _nachname;

        public Mitarbeiter(string vorname, string nachname)
        {
            _vorname = vorname;
            _nachname = nachname;
        }

        // Methode zur Ausgabe des Namens
        public void AusgabeName()
        {
            Console.WriteLine($"{_vorname} {_nachname}");
        }
    }

    // Klasse für Angestellte
    public class Angestellte : Mitarbeiter
    {
        private Tarifgruppe _tarifgruppe;
        private int _alter;
        private double _gehalt;

        public Angestellte(string vorname, string nachname, Tarifgruppe tarifgruppe, int alter) : base(vorname, nachname)
        {
            _tarifgruppe = tarifgruppe;
            _alter = alter;
        }

        // Berechnung des Gehalts für Angestellte
        public void GehaltBerechnen()
        {
            double basisgehalt = (double)_tarifgruppe;
            _gehalt = basisgehalt + (basisgehalt * (25 - _alter) / 100.0);
        }

        // Ausgabe des Namens und Gehalts
        public void Ausgabe()
        {
            AusgabeName();
            Console.WriteLine($"Gehalt: {_gehalt} €");
        }
    }

    // Klasse für Externe Mitarbeiter
    public class Externe : Mitarbeiter
    {
        private int _stunden;
        private double _gehalt;

        public Externe(string vorname, string nachname, int stunden) : base(vorname, nachname)
        {
            _stunden = stunden;
        }

        // Berechnung des Gehalts für Externe
        public void GehaltBerechnen()
        {
            _gehalt = _stunden * 75;
        }

        // Ausgabe des Namens und Gehalts
        public void Ausgabe()
        {
            AusgabeName();
            Console.WriteLine($"Gehalt: {_gehalt} €");
        }
    }

    // Klasse für Praktikanten
    public class Praktikant : Mitarbeiter
    {
        private string _abteilung;
        private double _gehalt;

        public Praktikant(string vorname, string nachname, string abteilung) : base(vorname, nachname)
        {
            _abteilung = abteilung;
        }

        // Berechnung des Gehalts für Praktikanten basierend auf der Abteilung
        public void GehaltBerechnen()
        {
            switch (_abteilung.ToLower())
            {
                case "entwicklung":
                    _gehalt = 935;
                    break;
                case "vertrieb":
                    _gehalt = 820;
                    break;
                case "produktion":
                    _gehalt = 710;
                    break;
                default:
                    _gehalt = 0;
                    break;
            }
        }

        // Ausgabe des Namens und Gehalts
        public void Ausgabe()
        {
            AusgabeName();
            Console.WriteLine($"Gehalt: {_gehalt} € (Abteilung: {_abteilung})");
        }
    }

    // Enum für die Tarifgruppen
    public enum Tarifgruppe
    {
        A = 2560,
        B = 3000,
        C = 3200,
        D = 5400
    }
}
