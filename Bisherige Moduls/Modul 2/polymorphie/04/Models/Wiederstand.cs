namespace _04.Models
{
    public class Wiederstand
    {
        protected double _wiederstandswert;
        protected string _wiederstandsname=string.Empty;
        public Wiederstand(double wiederstandswert,string wiederstandsname)
        {
            _wiederstandswert = wiederstandswert;
            _wiederstandsname = wiederstandsname;
        }
        protected Wiederstand()
        {

        }
        public double GetWiederstandswert()
        {
            return _wiederstandswert;
        }
        public string GetWiederstandsname()
        {
            return _wiederstandsname ;
        }
        public void Ausgabe()
        {
            Console.WriteLine($"{_wiederstandsname} : {_wiederstandswert}");
        }
    }
}
