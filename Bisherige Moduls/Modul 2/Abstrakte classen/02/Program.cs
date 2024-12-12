namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kreis kreis = new Kreis(3);
            Console.WriteLine(kreis.UmfangBerechnen());
            Console.WriteLine(kreis.Flächeberechnen());

            Quadrat quadrat = new Quadrat(5);
            Console.WriteLine(quadrat.UmfangBerechnen());
            Console.WriteLine(quadrat.Flächeberechnen());

            Rechteck rechteck = new Rechteck(2,3);
            Console.WriteLine(rechteck.UmfangBerechnen());
            Console.WriteLine(rechteck.Flächeberechnen());

        }
    }
    public abstract class GeometrieObjekt
    {
        public abstract double UmfangBerechnen();
        public abstract double Flächeberechnen();
    }
    public class Kreis : GeometrieObjekt 
    {
        private double _radius;
        public Kreis(int radius)
        {
            _radius = radius;   
        }
        public override double UmfangBerechnen()
        {
            return 2*Math.PI*_radius;
        }
        public override double Flächeberechnen()
        {
            return Math.PI*Math.Pow(_radius ,2);
        }
    }
    public class Quadrat : GeometrieObjekt
    {
        private int _seitenlänge;
        public Quadrat(int seitenlänge)
        {
            _seitenlänge = seitenlänge;
        }
        public override double UmfangBerechnen()
        {
            return 4 * _seitenlänge;
        }
        public override double Flächeberechnen()
        {
            return _seitenlänge * _seitenlänge;
        }

    }
    public class Rechteck : GeometrieObjekt
    {
        private int _seitenlängeA;
        private int _seitenlängeB;

        public Rechteck(int seitenlängeA,int seitenlängeB)
        {
            _seitenlängeA = seitenlängeA ;
            _seitenlängeB = seitenlängeB ;
        }
        public override double UmfangBerechnen()
        {
            return 2 * (_seitenlängeA+_seitenlängeB);
        }
        public override double Flächeberechnen()
        {
            return _seitenlängeA * _seitenlängeB;
        }
    }
}