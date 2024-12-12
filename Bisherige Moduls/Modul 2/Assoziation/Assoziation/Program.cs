using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Assoziation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person person1 = new Person("nj", "amir", 28);
            Addresse adresse = new Addresse("Musterstraße", "12", "12345", "Musterstadt");
            Console.WriteLine(person1.GetAlter());
            person1.Ausgabe();
            person1.SetNachname("jafari");
            person1.Ausgabe();
            person1.SetAdresse(adresse);
            adresse.Ausgabe();

            Hund hund1 = new Hund("jesi");
            person1.MitHundGassiGehen();
            person1.SetHund(hund1);
            hund1.GassiGehen();
            hund1.Füttern();
            hund1.GassiGehen();
            person1.MitHundGassiGehen();
            
        }
    }

    public class Person
    {
        private string _nachname;
        private string _vorname;
        private int _alter;
        private Addresse _addresse;
        private Hund _hund;

        public Person(string nachname, string vorname, int alter)
        {
            _nachname = nachname;
            _vorname = vorname;
            _alter = alter;
        }

        public string GetNachName()
        {
            return _nachname;
        }

        public string GetVorName()
        {
            return _vorname;
        }

        public int GetAlter()
        {
            return _alter;
        }

        public void SetNachname(string nachname)
        {
            _nachname = nachname;
        }

        public void SetAdresse(Addresse adresse)
        {
            _addresse = adresse;
        }

        public void Ausgabe()
        {
            Console.WriteLine($"Person: {_vorname} {_nachname}, Alter: {_alter}");
        }

        public void SetHund(Hund hund)
        {
            //wenn ich keine hund zu dem person zuweise dan habe ich kein hund oder hund=nul
            //aber wenn ich durch sethund einen hund zu dem perspn zuweisse dann ist nicht mehr null
            _hund = hund;
        }

        public void MitHundGassiGehen()
        {
            if (_hund == null)
            {
                Console.WriteLine($"{_vorname} hat keinen Hund.");
                return;
            }

            if (_alter < 16)
            {
                Console.WriteLine($"{_vorname} ist zu jung, um mit dem Hund Gassi zu gehen.");
                return;
            }

            _hund.GassiGehen();
        }
    }

    public class Addresse
    {
        private string _strasse;
        private string _hausnummer;
        private string _plz;
        private string _ort;

        public Addresse(string strasse, string hausnummer, string plz, string ort)
        {
            _strasse = strasse;
            _hausnummer = hausnummer;
            _plz = plz;
            _ort = ort;
        }

        public void Ausgabe()
        {
            Console.WriteLine($"Adresse: {_strasse} {_hausnummer} {_plz} {_ort}");
        }
    }

    public class Hund
    {
        private string _hundname;
        private bool _gefütern;

        public Hund(string name)
        {
            _hundname = name;
        }

        public void Füttern()
        {
            _gefütern = true;
            Console.WriteLine($"{_hundname} wurde gefüttert.");
        }

        public void GassiGehen()
        {
            if (_gefütern)
            {
                Console.WriteLine($"{_hundname} geht gassi.");
            }
            else
            {
                Console.WriteLine($"{_hundname} kann nicht Gassi gehen, weil der arme nichts gegessen hat.");
            }
        }

        public void Ausgabe()
        {
            string status = "ist nicht gefüttert";
            if (_gefütern)
            {
                status = "ist gefüttert";
            }
            Console.WriteLine($"Hund: {_hundname}, {status}");
        }
    }
}