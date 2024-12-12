namespace telefon
{
    internal class Program
    {
        static string[] kontakte = new string[0];

        public static void KontaktErstellen()
        {
            Console.WriteLine("Bitte Name eingeben:");
            string name = Console.ReadLine();

            // Überprüfen, ob der Name bereits existiert
            foreach (string kontakt in kontakte)
            {
                string[] details = kontakt.Split(';');
                if (details[0].ToLower() == name.ToLower())
                {
                    Console.WriteLine("Ein Kontakt mit diesem Namen existiert bereits.");
                    return;
                }
            }

            Console.WriteLine("Bitte Telefonnummer eingeben:");
            string telefon = Console.ReadLine();

            // Telefonnummer validieren
            if (!IstTelefonnummerGueltig(telefon))
            {
                Console.WriteLine("Ungültige Telefonnummer. Nur Ziffern sind erlaubt.");
                return;
            }

            Console.WriteLine("Bitte E-Mail-Adresse eingeben:");
            string email = Console.ReadLine();

            // E-Mail-Adresse validieren
            if (!IstEmailGueltig(email))
            {
                Console.WriteLine("Ungültige E-Mail-Adresse. Es muss ein '@' enthalten sein.");
                return;
            }

            // Kontakt speichern
            string kontaktInfo = $"{name};{telefon};{email}";
            Array.Resize(ref kontakte, kontakte.Length + 1);
            kontakte[kontakte.Length - 1] = kontaktInfo;

            Console.WriteLine("Kontakt erfolgreich hinzugefügt!");
        }

        public static bool IstTelefonnummerGueltig(string telefon)
        {
            return telefon.All(char.IsDigit);
        }
       


        public static bool IstEmailGueltig(string email)
        {
            return email.Contains("@");
        }

        public static void KontaktAnzeigen()
        {
            if (kontakte.Length == 0)
            {
                Console.WriteLine("Keine Kontakte vorhanden.");
                return;
            }

            foreach (string kontakt in kontakte)
            {
                string[] details = kontakt.Split(';');
                Console.WriteLine($"Name: {details[0]}, Telefon: {details[1]}, Email: {details[2]}");
            }
        }

        public static void KontaktSuchen()
        {
            bool kontaktGefunden = false;
            Console.WriteLine("Bitte den Namen eingeben, nach dem gesucht werden soll:");
            string suchName = Console.ReadLine();

            foreach (string kontakt in kontakte)
            {
                string[] details = kontakt.Split(';');
                if (details[0].ToLower() == suchName.ToLower())
                {
                    Console.WriteLine($"Kontakt gefunden: Name: {details[0]}, Telefon: {details[1]}, Email: {details[2]}");
                    kontaktGefunden = true;
                }
            }

            if (!kontaktGefunden)
            {
                Console.WriteLine("Kein Kontakt gefunden.");
            }
        }

        public static void KontakteSortieren(bool aufsteigend)
        {
            if (kontakte.Length == 0)
            {
                Console.WriteLine("Keine Kontakte vorhanden.");
                return;
            }

            if (aufsteigend)
            {
                Array.Sort(kontakte, (x, y) => x.Split(';')[0].CompareTo(y.Split(';')[0]));
                Console.WriteLine("Kontakte aufsteigend sortiert.");
            }
            else
            {
                Array.Sort(kontakte, (x, y) => y.Split(';')[0].CompareTo(x.Split(';')[0]));
                Console.WriteLine("Kontakte absteigend sortiert.");
            }

            KontaktAnzeigen();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWillkommen im Kontaktbuch");
                Console.WriteLine("(1) Neuen Kontakt hinzufügen");
                Console.WriteLine("(2) Kontakte anzeigen");
                Console.WriteLine("(3) Kontakt suchen");
                Console.WriteLine("(4) Kontakte sortieren");
                Console.WriteLine("(5) Programm beenden");
                Console.Write("Wähle eine Option: ");

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
                        Console.WriteLine("Sortiere Kontakte:");
                        Console.WriteLine("(a) Aufsteigend");
                        Console.WriteLine("(b) Absteigend");
                        string sortOption = Console.ReadLine();

                        if (sortOption.ToLower() == "a")
                            KontakteSortieren(true);
                        else if (sortOption.ToLower() == "b")
                            KontakteSortieren(false);
                        else
                            Console.WriteLine("Ungültige Option.");
                        break;
                    case "5":
                        return; // Programm beenden
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte wähle eine gültige Option.");
                        break;
                }
            }
        }
    }
}
