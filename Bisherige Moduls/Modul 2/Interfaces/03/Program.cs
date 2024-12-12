namespace _03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            Temperatur temp = new Temperatur();

            temp.Celsius = 10;
            ((ICelsius)temp).Ausgabe(); 
            ((IFarenheit)temp).Ausgabe(); 
            ((IKelvin)temp).Ausgabe(); 

            temp.Farenheit = 50;
            ((ICelsius)temp).Ausgabe(); 
            ((IFarenheit)temp).Ausgabe(); 
            ((IKelvin)temp).Ausgabe();
        }
    }

    public interface ICelsius
    {
        double Celsius { get; set; }

        void Ausgabe();
    }

    public interface IFarenheit
    {
        double Farenheit { get; set; }

        void Ausgabe();
    }

    public interface IKelvin
    {
        double Kelvin { get; set; }

        void Ausgabe();
    }

    public class Temperatur : IKelvin, ICelsius, IFarenheit
    {
        private double _temperatur;

        public double Celsius
        {
            get { return _temperatur; }
            set { _temperatur = value; }
        }

        public double Farenheit
        {
            get { return (_temperatur * 9) / 5 + 32; }
            set { _temperatur = (value - 32) * 5 / 9; }
        }

        public double Kelvin
        {
            get { return _temperatur + 273.15; }
            set { _temperatur = value - 273.15; }
        }
        void ICelsius.Ausgabe()
        {
            Console.WriteLine($"{Celsius} C");
        }

        void IFarenheit.Ausgabe()
        {
            Console.WriteLine($"{Farenheit} F");
        }

        void IKelvin.Ausgabe()
        {
            Console.WriteLine($"{Kelvin} K");
        }
    }
}



