namespace _01
{
    public class Bruch
    {
        private int _zähler;
        private int _nenner;

        public Bruch(int zähler) : this(zähler, 1)
        {
        }

        public Bruch(int zähler, int nenner)
        {
            _zähler = zähler;
            _nenner = nenner;
        }

        public void Ausgabe()
        {
            Console.WriteLine($"{_zähler}/{_nenner}");
        }

        public Bruch Gekehrtweg()
        {
            Bruch gekehrt = new Bruch(_nenner, _zähler);
            return gekehrt;
        }

        private int GGT(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public Bruch kürzen()
        {
            int teiler = GGT(_zähler, _nenner);
            return new Bruch(_zähler / teiler, _nenner / teiler);
        }

        public Bruch Addiere(Bruch b)
        {
            int x = _zähler * b._nenner;
            int y = b._zähler * _nenner;
            int z = _nenner * b._nenner;
            return new Bruch(x + y, z).kürzen();
        }
        public Bruch Multi(Bruch b)
        {
            int oben = _zähler * b._zähler;
            int unten = _nenner * b._nenner;
            return new Bruch (oben,unten).kürzen();
        }
        public Bruch subt(Bruch b)
        {
            int x = _zähler * b._nenner;
            int y = b._zähler * _nenner;
            int z = _nenner * b._nenner;
            return new Bruch(x - y, z).kürzen();
        }
        public Bruch Division(Bruch b)
        {
            int x = _zähler * b._nenner;
            int y = _nenner * b._zähler;
            return new Bruch(x, y).kürzen();
        }
    }
}
