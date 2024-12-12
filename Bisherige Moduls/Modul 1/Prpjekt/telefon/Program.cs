namespace telefon
{
    internal class Program
    {
        private static string[] kontakte = new string[0];

        public static void KontaktErstellen()
        {
            ////////////////////////////////name

            Console.WriteLine("please write name");
            string name = Console.ReadLine();
            foreach (string kontakt in kontakte)
            {
                string[] details = kontakt.Split(';');
                while (details[0].ToLower() == name.ToLower())
                {
                    Console.WriteLine("dieser name ist schon drin . try again");
                    name = Console.ReadLine();
                }
            }
            //////////////////////////////// telefon

            Console.WriteLine("telefon");
            string telefon = Console.ReadLine();
            while (!IstTelefonnummerGueltig(telefon))
            {
                Console.WriteLine("Ungültige telefon. nur Ziffern sind ok. Try again");
                telefon = Console.ReadLine();
            }
            /////////////////////////////// email
            Console.WriteLine("email");
            string email = Console.ReadLine();
            while (!IstEmailGueltig(email))
            {
                Console.WriteLine("Ungültig email.  (@) soll da sein. Try again");
                email = Console.ReadLine();
            }
            //zusammen fassung
            string Kontakt = $"{name};{telefon};{email}";

            //array vergrössern
            Array.Resize(ref kontakte, kontakte.Length +1);
            //kontakz in array hinzufügen
            kontakte[kontakte.Length - 1] = Kontakt;
            Console.WriteLine("ok!");
            Console.WriteLine($"{name}  {telefon}  {email} wurde gespeichert");
        }

        public static void KontaktAnzeigen()
        {
            if (kontakte.Length == 0) // wenn keine kontakte vorhanden ist
            {
                Console.WriteLine("keine Kontakt wurde gespeichert");
                return;
            }
            foreach (string kontakt in kontakte) // kontakten von einander getränt machen
            {
                string[] details = kontakt.Split(';');
                Console.WriteLine($"Name: {details[0]}, telefon: {details[1]}, Email: {details[2]}");
            }
        }

        public static void KontaktSuchen()
        {
            bool KontaktGefunden = false;
            Console.WriteLine("please give your name that you want to search");
            string suchName = Console.ReadLine();
            foreach (string kontakt in kontakte)//wenn eingegebene suchname gefunden wird
            {
                string[] details = kontakt.Split(';');
                if (details[0].ToLower() == suchName.ToLower())
                {
                    Console.WriteLine($"ok {details[0]} wurde gefunden und hier sind weitere infos ({details[1]}) ({details[2]})");
                    KontaktGefunden = true;
                }
            }
            //wenn eingegebene suchname nicht gefunden wird

            if (!KontaktGefunden)
            {
                Console.WriteLine("keine kontakt wurde gefunden");
            }
        }

        public static bool IstTelefonnummerGueltig(string telefon)//prüft ob telefon nr its
        {
            foreach (char c in telefon)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IstEmailGueltig(string email)//prüft ob email Gültig ist
        {
            return email.Contains("@");
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                //welche option
                Console.WriteLine("wilkommen in ihrem Kontaktbuch");
                Console.WriteLine();
                Console.WriteLine("(option 1) -> new kontakt");
                Console.WriteLine();
                Console.WriteLine("(option 2) -> show kontakt");
                Console.WriteLine();
                Console.WriteLine("(option 3) -> search kontakt");
                Console.WriteLine();
                Console.WriteLine("(option 4) -> finish");
                Console.WriteLine();
                Console.WriteLine("choose your choise");
                Console.WriteLine();

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        KontaktErstellen();
                        break;

                    case "2":
                        KontaktAnzeigen();
                        break;

                    case "3":
                        KontaktSuchen();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Falsche eingabe");
                        break;
                }
            }
        }
    }
}