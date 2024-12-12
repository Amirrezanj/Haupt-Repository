namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fledermaus fledermaus = new Fledermaus();
            Singvogel singvogel = new Singvogel();
            Biene biene = new Biene();

            fledermaus.Fliegen();
            singvogel.Fliegen();
            singvogel.Singen();
            biene.Fliegen();
        }
    }
    public interface IFliegen
    {
        void Fliegen();
    }
    public interface Isingen
    {
        void Singen();
    }

    public class Biene : IFliegen 
    {
        public void Fliegen()
        {
            Console.WriteLine("Summsumm");
        }
    }
    public class Fledermaus : IFliegen
    {
        public void Fliegen()
        {
            Console.WriteLine("Flatter flatter");
        }
    }
    public class Singvogel : IFliegen, Isingen
    {
        public void Fliegen()
        {
            Console.WriteLine("FlapFlap");
        }
        public void Singen()
        {
            Console.WriteLine("Zwitscherzwitscher");
        }
    }
}
