namespace GenerischeFlascheApp
{
    public abstract class Getränk
    {
        public string Name { get; set; }

        public Getränk(string name)
        {
            Name = name;
        }
    }

    public class Bier : Getränk
    {
        public string Brauerei { get; set; }

        public Bier(string name, string brauerei) : base(name)
        {
            Brauerei = brauerei;
        }

        public string GibBrauerei()
        {
            return Brauerei;
        }

        public void ZeigeInfo()
        {
            Console.WriteLine($"Bier: {Name}, Brauerei: {Brauerei}");
        }
    }

    public class Rotwein : Getränk
    {
        public string Herkunft { get; set; }

        public Rotwein(string name, string herkunft) : base(name)
        {
            Herkunft = herkunft;
        }

        public string GibHerkunft()
        {
            return Herkunft;
        }

        public void ZeigeInfo()
        {
            Console.WriteLine($"Rotwein: {Name}, Herkunft: {Herkunft}");
        }
    }

    public class Weißwein : Getränk
    {
        public string Herkunft { get; set; }

        public Weißwein(string name, string herkunft) : base(name)
        {
            Herkunft = herkunft;
        }

        public string GibHerkunft()
        {
            return Herkunft;
        }

        public void ZeigeInfo()
        {
            Console.WriteLine($"Weißwein: {Name}, Herkunft: {Herkunft}");
        }
    }

    public class Flasche<T> where T : Getränk
    {
        private T _inhalt;

        public T Inhalt => _inhalt;

        public bool IstLeer()
        {
            return _inhalt == null;
        }

        public void Füllen(T getränk)
        {
            if (IstLeer())
            {
                _inhalt = getränk;
                Console.WriteLine($"{_inhalt.Name} wurde in die Flasche gefüllt.");
            }
            else
            {
                Console.WriteLine("Die Flasche ist bereits gefüllt.");
            }
        }

        public T Leeren()
        {
            if (!IstLeer())
            {
                T temp = _inhalt;
                _inhalt = null;
                Console.WriteLine($"{temp.Name} wurde aus der Flasche geleert.");
                return temp;
            }
            else
            {
                Console.WriteLine("Die Flasche ist schon leer.");
                return null;
            }
        }
    }
}
