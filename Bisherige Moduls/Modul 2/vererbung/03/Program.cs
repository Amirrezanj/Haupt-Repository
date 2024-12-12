

namespace BankSystem
{
    // Klasse Inhaber
    public class Inhaber
    {
        private string vorname;
        private string nachname;

        public Inhaber(string vorname, string nachname)
        {
            this.vorname = vorname;
            this.nachname = nachname;
        }

        public string GetName()
        {
            return $"{vorname} {nachname}";
        }
    }

    public class Konto
    {
        private static Random zufallszahlengenerator = new Random();
        private int kontonummer;
        protected double kontostand;
        private DateTime eröffnungsDatum;
        private double habenzinssatz;

        public Konto(Inhaber inhaber, double startguthaben, double habenzinssatz)
        {
            kontonummer = zufallszahlengenerator.Next(100000, 999999);
            kontostand = startguthaben;
            this.habenzinssatz = habenzinssatz;
            eröffnungsDatum = DateTime.Now;
        }

        public void Einzahlen(double guthaben)
        {
            kontostand += guthaben;
        }

        public void BerechneZinsen()
        {
            kontostand += kontostand * (habenzinssatz / 100);
        }

        public void KontostandAusgeben()
        {
            Console.WriteLine($"Kontostand für Konto {kontonummer}: {kontostand} Euro");
        }
    }

    public class Girokonto : Konto
    {
        private double dispo;
        private double dispozins;
        private Kategorie kategorie;

        public Girokonto(Inhaber inhaber, double startguthaben, double dispo, Kategorie kategorie)
            : base(inhaber, startguthaben, 0) // Girokonto hat 0% Habenzinsen
        {
            this.dispo = dispo;
            this.kategorie = kategorie;
            this.dispozins = 16; // Dispozins fest auf 16%
        }

        public void Auszahlen(double betrag)
        {
            double maxVerfügbarerBetrag = kontostand + dispo;
            if (betrag <= maxVerfügbarerBetrag)
            {
                kontostand -= betrag;
                if (kontostand < 0)
                {
                    double überzogenerBetrag = -kontostand;
                    double zinsen = überzogenerBetrag * (dispozins / 100);
                    Console.WriteLine($"Konto überzogen, Sollzinsen von {zinsen} Euro fällig.");
                }
            }
            else
            {
                Console.WriteLine("Der Betrag übersteigt den Disporahmen!");
            }
        }
    }

    // Spezialisierung für Festgeldkonto
    public class Festgeldkonto : Konto
    {
        private int laufzeit; // in Jahren
        private DateTime startDatum;

        public Festgeldkonto(Inhaber inhaber, double startguthaben, int laufzeit)
            : base(inhaber, startguthaben, 2) // Festgeldkonto hat 2% Habenzinsen
        {
            this.laufzeit = laufzeit;
            this.startDatum = DateTime.Now;
        }

        public bool IstRestlaufzeitErreicht()
        {
            DateTime endDatum = startDatum.AddYears(laufzeit);
            return DateTime.Now >= endDatum;
        }

        public void Restlaufzeit()
        {
            DateTime endDatum = startDatum.AddYears(laufzeit);
            TimeSpan restzeit = endDatum - DateTime.Now;

            if (restzeit.Days > 365)
            {
                Console.WriteLine($"Restlaufzeit: {restzeit.Days / 365} Jahre");
            }
            else if (restzeit.Days > 30)
            {
                Console.WriteLine($"Restlaufzeit: {restzeit.Days / 30} Monate");
            }
            else
            {
                Console.WriteLine($"Restlaufzeit: {restzeit.Days} Tage");
            }
        }
    }

    // Spezialisierung für Sparkonto
    public class Sparkonto : Konto
    {
        public Sparkonto(Inhaber inhaber, double startguthaben)
            : base(inhaber, startguthaben, 0.5) // Sparkonto hat 0.5% Habenzinsen
        {
        }

        // Sparkonto nutzt die Basismethoden von Konto für Einzahlen und Zinsen
    }

    // Enum für Kategorien
    public enum Kategorie
    {
        Standard,
        Schüler,
        Student,
        Gewerblich
    }

    // Hauptprogramm
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Testen der verschiedenen Konten
            Inhaber person1 = new Inhaber("Max", "Mustermann");

            // Girokonto
            Girokonto giro = new Girokonto(person1, 5000, 1000, Kategorie.Standard);
            giro.Einzahlen(200);
            giro.Auszahlen(6000); // Dispokredit wird verwendet
            giro.KontostandAusgeben();
            giro.BerechneZinsen();
            giro.KontostandAusgeben();

            // Sparkonto
            Sparkonto spar = new Sparkonto(person1, 10000);
            spar.Einzahlen(1000);
            spar.BerechneZinsen();
            spar.KontostandAusgeben();

            // Festgeldkonto
            Festgeldkonto festgeld = new Festgeldkonto(person1, 20000, 3);
            festgeld.BerechneZinsen();
            festgeld.KontostandAusgeben();
            festgeld.Restlaufzeit();
        }
    }
}
