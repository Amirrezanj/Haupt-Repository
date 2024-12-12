using _03.Models;

namespace _03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bürger bürger = new Bürger(100);
            Console.WriteLine(bürger.GetZuVersteuerndesEinkommen());
            Console.WriteLine(bürger.BerechneSteuern());
            Console.WriteLine();

            Adel adel = new Adel(100);
            Console.WriteLine(adel.GetZuVersteuerndesEinkommen());
            Console.WriteLine(adel.BerechneSteuern());
            Console.WriteLine();

            König könig = new König(100);
            Console.WriteLine(könig.GetZuVersteuerndesEinkommen());
            Console.WriteLine(könig.BerechneSteuern());
            Console.WriteLine();

            Leibeigenen leibeigenen = new Leibeigenen(100);
            Console.WriteLine(leibeigenen.GetZuVersteuerndesEinkommen());
            Console.WriteLine(leibeigenen.BerechneSteuern());
            Console.WriteLine();

            SteuerEintreiber steuerEintreiber = new SteuerEintreiber(1,adel,könig,bürger,leibeigenen);
            Console.WriteLine(steuerEintreiber.GetGesamtSteuer());
        }
    }
}