namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bruch x = new Bruch(8,16);
            Bruch y = new Bruch(2,3);
            x.Ausgabe();
            x.Gekehrtweg().Ausgabe();
            x.Addiere(y).Ausgabe();
            x.Multi(y).Ausgabe();
            x.subt(y).Ausgabe();
            









        }
    }
}
