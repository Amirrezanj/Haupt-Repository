namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Homer homer = new Homer();
            Simpson simpson1=new Simpson("magie");

        }
    }
    public class Simpson
    {
        protected string _vorname;
        protected string _nachname = "Simpson";
        protected string _hautfarbe = "Gelb";
        protected string _wohnort = "Evergreen Terrace 742, Springfield";

        public Simpson(string vorname)
        {
            _vorname = vorname;
        }

        public void SichVorstellen()
        {
            Console.WriteLine($"Hallo, ich bin {_vorname} {_nachname}, ich wohne in {_wohnort} und Hautfarbe ist {_hautfarbe}.");
        }

    }
    public class Homer : Simpson
    {
        private int _donutZähler;
        public Homer() : base("Hommer")
        {
        }
        public void DonutEssen()
        {
            _donutZähler++;
            Console.WriteLine("Homer hat ein Donut gegessen.");
        }
        public void ZählerAusgeben()
        {
            Console.WriteLine($"Homer hat {_donutZähler} Donuts gegessen.");
        }
    }
    public class Marge : Simpson
    {
        private int _haushaltZähler;
        public Marge():base("Marge")
        {
        }
        public void HaushaltKümmern()
        {
            _haushaltZähler++;
            Console.WriteLine("Marge hat sich um den Haushalt gekümmert.");
        }
        public void ZählerAusgeben()
        {
            Console.WriteLine($"Marge hat sich {_haushaltZähler} Mal um den Haushalt gekümmert.");
        }
    }
    public class Bart : Simpson
    {
        private int _skateboardZähler;
        public Bart() : base("Bart")
        {
        }

        public void SkateboardFahren()
        {
            _skateboardZähler++;
            Console.WriteLine("bart ist skateboard gefahren");
        }
        public void ZählerAusgabe()
        {
            Console.WriteLine("marge ist "+ _skateboardZähler +" mal skate gefahren"));
        }
    }
    public class Lisa : Simpson
    {
        private int _saxophonzähler;
        public Lisa(): base ("Lisa")
        {
        }
        public void Saxophon()
        {
            _saxophonzähler++;
            Console.WriteLine("marge hat saxophon gespielt");
        }
        public void ZählerAusgabe()
        {
            Console.WriteLine($"Lisa hat {_saxophonzähler} mal saxoohon gespielt");
        }
        public class Maggie : Simpson
        {
            private int _schnullergenuckelt;
            public Maggie() : base("Magie")
            {
            }
            public void SchnullerGenuckelt()
            {
                _schnullergenuckelt+++;
                Console.WriteLine("ok hat er");
            }
            public void ZählerAusgabe()
            {
                Console.WriteLine($"Maggie hat {_schnullergenuckelt} mal Schnuller genuckelt");
            }

        }
    }
}