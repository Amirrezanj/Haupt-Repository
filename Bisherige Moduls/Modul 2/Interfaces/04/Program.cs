namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fluss fluss = new Fluss();
            BuffaloBeobachter buffaloBeobachter = new BuffaloBeobachter(); 
            WalkwayBeobachter walkwayBeobachter = new WalkwayBeobachter();
            StrasseBeobachter strasseBeobachter = new StrasseBeobachter();
            
            

            // Beobachter anmelden
            fluss.anmelden(buffaloBeobachter);
            fluss.anmelden(walkwayBeobachter);
            fluss.anmelden(strasseBeobachter);

            fluss.WasserstandsÄndern();

            fluss.WasserstandsÄndern();

        }
    }
    public interface IBeobachter
    {
        void Wasserstandsänderung(int wasserstand);
    }
    public class BuffaloBeobachter : IBeobachter
    {
       
        public void Wasserstandsänderung(int wasserstand)
        {
            if (wasserstand <= 2)
            {
                Console.WriteLine("Buffalo: Wasserstand zu niedrig, Büffel müssen zusätzlich getränkt werden.");
            }
            else if (wasserstand >= 7)
            {
                Console.WriteLine("Buffalo: Wasserstand sehr hoch, Büffel müssen vom Fluss entfernt werden.");
            }
            else
            {
                Console.WriteLine("Buffalo: Wasserstand ist normal.");
            }
        }
    }
    public class WalkwayBeobachter : IBeobachter
    {
        public void Wasserstandsänderung(int wasserstand)
        {
            if (wasserstand <= 1)
            {
                Console.WriteLine("Walkway: Wasserstand niedrig, der Weg ist sicher begehbar.");
            }
            else if (wasserstand >= 6)
            {
                Console.WriteLine("Walkway: Wasserstand hoch, der Wanderweg ist überschwemmt.");
            }
            else
            {
                Console.WriteLine("Walkway: Wasserstand ist normal.");
            }
        }
    }
    public class StrasseBeobachter : IBeobachter
    {
        public void Wasserstandsänderung(int wasserstand)
        {
            if (wasserstand >= 9)
            {
                Console.WriteLine("Strasse: Wasserstand sehr hoch, Straße ist überschwemmt und muss gesperrt werden.");
            }
            else if (wasserstand >= 5)
            {
                Console.WriteLine("Strasse: Vorsicht, Wasserstand steigt,Gefahr für die Straße.");
            }
            else
            {
                Console.WriteLine("Strasse: Wasserstand ist sicher.");
            }
        }
    }
    public class Fluss
    {
        List<IBeobachter> list = new List<IBeobachter>();
        public void anmelden(IBeobachter beobachter)
        {
            list.Add(beobachter);
        }
        public void WasserstandsÄndern()
        {
            Random random = new Random();
            int temp=random.Next(1,10);
            foreach (IBeobachter b in list)
            {
                b.Wasserstandsänderung(temp);
                Console.WriteLine(temp);
            }
        }
    }
}