namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            person person1 = new person();
            person person2 = new person();

            ra
        }
    }
    public interface INachrichtenEmpfänger
    {
        // Übergabe einer neuen Nachricht
        void EmpfangeNachricht(string nachricht);
    }
    public interface INachrichtenQuelle
    {
        // Interessierte können sich bei der Quelle anmelden
        // (falls sie noch nicht angemeldet sind)
        void Anmelden(INachrichtenEmpfänger empfänger);
        // Angemeldete können sich bei der Quelle wieder abmelden
        // (falls sie angemeldet sind)
        void Abmelden(INachrichtenEmpfänger empfänger);
        // neue Nachricht wird an alle angemeldeten Empfänger übergeben
        // (Aufruf deren Methode EmpfangeNachricht)
        void SendeNachricht(string nachricht);
    }
    public class Quelle : INachrichtenQuelle
    {
        private List<INachrichtenEmpfänger> _empfängerliste = new List<INachrichtenEmpfänger> ();
        public void Anmelden(INachrichtenEmpfänger empfänger)
        {
            _empfängerliste.Add(empfänger);
        }
        public void Abmelden(INachrichtenEmpfänger empfänger)
        {
            _empfängerliste.Remove(empfänger);

        }
        public void SendeNachricht(string nachricht)
        {
            foreach (INachrichtenEmpfänger empfänger in _empfängerliste)
            {
                empfänger.EmpfangeNachricht(nachricht);
            }
        }
    }
    public class person : INachrichtenEmpfänger
    {
        public void EmpfangeNachricht(string nachricht)
        {
            Console.WriteLine($"nachricht erhalten : {nachricht}");
        }
    }
    public class Vermittler : INachrichtenQuelle, INachrichtenEmpfänger
    {
        private List<INachrichtenEmpfänger> _empfängerliste = new List<INachrichtenEmpfänger>();
        public void Anmelden(INachrichtenEmpfänger empfänger)
        {
            _empfängerliste.Add(empfänger);
        }
        public void Abmelden(INachrichtenEmpfänger empfänger)
        {
            _empfängerliste.Remove(empfänger);
        }
        public void SendeNachricht(string nachricht)
        {
            foreach (INachrichtenEmpfänger empfänger in _empfängerliste)
            {
                empfänger.EmpfangeNachricht(nachricht);
            }
        }
        public void EmpfangeNachricht(string nachricht)
        {
            SendeNachricht(nachricht);
        }
    }
}
