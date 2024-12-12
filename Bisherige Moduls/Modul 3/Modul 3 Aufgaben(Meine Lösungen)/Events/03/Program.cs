using FlussSimulation;

namespace _03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Fluss
    {
        private string _name;
        private int _wasserstand;
        private Random _random;

        public Fluss(string name, int wasserstand)
        {
            _name = name;
            _wasserstand = wasserstand;
        }

        public event EventHandler<WasserstandsÄnderungEventArg>? WasserstandGeändert;
    }

    public class WasserstandsÄnderungEventArg : EventArgs
    {
        public int AlterWasserstand { get; }
        public int NeuerWasserstand { get; }
        public DateTime Zeitpunkt { get; }

        public WasserstandsÄnderungEventArg(int alterWasserstand, int neuerWasserstand, DateTime zeitpunkt)
        {
              AlterWasserstand = alterWasserstand;
              NeuerWasserstand = neuerWasserstand;
              Zeitpunkt = zeitpunkt;
        }
    }
    public abstract class FlussBeobachter
    {
        private string ? _name;
        private Fluss _flus;
        protected abstract void ReagiereAufWasserstandsÄnderung(object? sender, WasserstandsÄnderungEventArg e);

        public FlussBeobachter(string name , Fluss fluss)
        {
            _name = name ;
            _flus = fluss;
        }
    }
    public class stadt : FlussBeobachter
    {
        public stadt(string name, Fluss fluss) :base(name,fluss)
        {
        }

        protected override void ReagiereAufWasserstandsÄnderung(object? sender, WasserstandsÄnderungEventArg e)
        {

        }
    }
}





using System;

namespace FlussSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Flüsse erstellen
            Fluss rhein = new Fluss("Rhein", 5000);
            Fluss donau = new Fluss("Donau", 6000);

            // Beobachter für den Rhein
            Stadt köln = new Stadt("Köln", rhein);
            Stadt düsseldorf = new Stadt("Düsseldorf", rhein);
            Schiff rheingold = new Schiff("Rheingold", rhein);
            Schiff lorelei = new Schiff("Lorelei", rhein);

            // Beobachter für die Donau
            Schiff xaver = new Schiff("Xaver", donau);
            Schiff franz = new Schiff("Franz", donau);
            Klärwerk strauss1 = new Klärwerk("Strauß 1", donau);

            // Simulation starten
            Console.WriteLine("Simulation für Rhein:");
            rhein.SimuliereWasserstandsÄnderung();

            Console.WriteLine("\nSimulation für Donau:");
            donau.SimuliereWasserstandsÄnderung();
        }
    }

    public class Fluss
    {
        public string Name { get; }
        private int _wasserstand;
        private readonly Random _random;

        public Fluss(string name, int wasserstand)
        {
            Name = name;
            _wasserstand = wasserstand;
            _random = new Random();
        }

        // Ein Event für Wasserstandänderungen und kritische Werte
        public event EventHandler<WasserstandsÄnderungEventArgs>? WasserstandGeändert;

        public void SimuliereWasserstandsÄnderung()
        {

            int alterWasserstand = _wasserstand;
            _wasserstand += _random.Next(-2000, 2000); // Zufällige Änderung

            // Grenzen setzen
            if (_wasserstand < 100) _wasserstand = 100;
            if (_wasserstand > 10000) _wasserstand = 10000;

            // Wasserstandsänderung melden
            OnWasserstandGeändert(new WasserstandsÄnderungEventArgs(alterWasserstand, _wasserstand, DateTime.Now));


        }

        protected virtual void OnWasserstandGeändert(WasserstandsÄnderungEventArgs e)
        {
            WasserstandGeändert?.Invoke(this, e);
        }
    }

    public class WasserstandsÄnderungEventArgs : EventArgs
    {
        public int AlterWasserstand { get; }
        public int NeuerWasserstand { get; }
        public DateTime Zeitpunkt { get; }

        public WasserstandsÄnderungEventArgs(int alterWasserstand, int neuerWasserstand, DateTime zeitpunkt)
        {
            AlterWasserstand = alterWasserstand;
            NeuerWasserstand = neuerWasserstand;
            Zeitpunkt = zeitpunkt;
        }
    }

    public abstract class FlussBeobachter
    {
        protected string Name { get; }
        protected Fluss Fluss { get; }

        protected FlussBeobachter(string name, Fluss fluss)
        {
            Name = name;
            Fluss = fluss;
            Fluss.WasserstandGeändert += ReagiereAufWasserstandsÄnderung;
        }

        protected abstract void ReagiereAufWasserstandsÄnderung(object? sender, WasserstandsÄnderungEventArgs e);
    }

    public class Stadt : FlussBeobachter
    {
        public Stadt(string name, Fluss fluss) : base(name, fluss) { }

        protected override void ReagiereAufWasserstandsÄnderung(object? sender, WasserstandsÄnderungEventArgs e)
        {
            Console.WriteLine($"Stadt {Name}: Wasserstand im {Fluss.Name} hat sich geändert: {e.AlterWasserstand} -> {e.NeuerWasserstand} (Zeit: {e.Zeitpunkt.ToLongTimeString()})");

            // Reagiere auf kritischen Wasserstand
            if (e.NeuerWasserstand > 8200)
            {
                Console.WriteLine($"Stadt {Name}: WARNUNG! Wasserstand im {Fluss.Name} ist kritisch: {e.NeuerWasserstand} (Zeit: {e.Zeitpunkt.ToLongTimeString()})");
                Console.WriteLine($"Stadt {Name}: Wasserschutzwand wird errichtet!");
            }
        }
    }

    public class Schiff : FlussBeobachter
    {
        public Schiff(string name, Fluss fluss) : base(name, fluss) { }

        protected override void ReagiereAufWasserstandsÄnderung(object? sender, WasserstandsÄnderungEventArgs e)
        {
            Console.WriteLine($"Schiff {Name}: Wasserstand in der {Fluss.Name} hat sich geändert: {e.AlterWasserstand} -> {e.NeuerWasserstand} (Zeit: {e.Zeitpunkt.ToLongTimeString()})");

            // Reagiere auf kritischen Wasserstand
            if (e.NeuerWasserstand < 250 || e.NeuerWasserstand > 8000)
            {
                Console.WriteLine($"Schiff {Name}: WARNUNG! Wasserstand in der {Fluss.Name} ist kritisch: {e.NeuerWasserstand} (Zeit: {e.Zeitpunkt.ToLongTimeString()})");
                Console.WriteLine($"Schiff {Name}: Das Schiff stoppt!");
            }
        }
    }

    public class Klärwerk : FlussBeobachter
    {
        public Klärwerk(string name, Fluss fluss) : base(name, fluss) { }

        protected override void ReagiereAufWasserstandsÄnderung(object? sender, WasserstandsÄnderungEventArgs e)
        {
            Console.WriteLine($"Klärwerk {Name}: Wasserstand in der {Fluss.Name} hat sich geändert: {e.AlterWasserstand} -> {e.NeuerWasserstand} (Zeit: {e.Zeitpunkt.ToLongTimeString()})");

            // Reagiere auf kritischen Wasserstand
            if (e.NeuerWasserstand > 8000)
            {
                Console.WriteLine($"Klärwerk {Name}: WARNUNG! Wasserstand in der {Fluss.Name} ist kritisch: {e.NeuerWasserstand} (Zeit: {e.Zeitpunkt.ToLongTimeString()})");
                Console.WriteLine($"Klärwerk {Name}: Einleitungen werden gestoppt!");
            }
            else if (e.NeuerWasserstand < 3000)
            {
                Console.WriteLine($"Klärwerk {Name}: Wasserstand in der {Fluss.Name} ist niedrig: {e.NeuerWasserstand} (Zeit: {e.Zeitpunkt.ToLongTimeString()})");
                Console.WriteLine($"Klärwerk {Name}: Einleitungen werden erhöht!");
            }
        }
    }
}