using System;

namespace Kontaktverwaltung
{
    internal class Program
    {
        private static string[] kontakte = new string[0];

        // Kontakt hinzufügen
        private static void KontaktHinzufuegen()
        {
            Console.Write("Geben Sie den Namen ein: ");
            string name = Console.ReadLine();
            Console.Write("Geben Sie die Telefonnummer ein: ");
            string telefonnummer = Console.ReadLine();
            Console.Write("Geben Sie die E-Mail-Adresse ein: ");
            string email = Console.ReadLine();

            // Kontakt als String speichern
            string kontakt = $"{name};{telefonnummer};{email}";

            // Array vergrößern, um den neuen Kontakt aufzunehmen
            Array.Resize(ref kontakte, kontakte.Length + 1); // Dynamische Erweiterung des Arrays
            kontakte[kontakte.Length - 1] = kontakt; // Neuen Kontakt hinzufügen

            Console.WriteLine("Kontakt erfolgreich hinzugefügt!");
        }

        // Kontakte anzeigen
        private static void KontakteAnzeigen()
        {
            if (kontakte.Length == 0)
            {
                Console.WriteLine("Keine Kontakte vorhanden.");
                return;
            }

            Console.WriteLine("\nGespeicherte Kontakte:");
            foreach (string kontakt in kontakte)
            {
                // Kontaktinformationen formatieren
                string[] details = kontakt.Split(';');
                Console.WriteLine($"Name: {details[0]}, Telefonnummer: {details[1]}, E-Mail: {details[2]}");
            }
        }

        // Kontakt suchen
        private static void KontaktSuchen()
        {
            Console.Write("Geben Sie den Namen ein, nach dem Sie suchen möchten: ");
            string suchName = Console.ReadLine();
            bool kontaktGefunden = false;

            foreach (string kontakt in kontakte)
            {
                string[] details = kontakt.Split(';');
                if (details[0].Equals(suchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Gefundener Kontakt - Name: {details[0]}, Telefonnummer: {details[1]}, E-Mail: {details[2]}");
                    kontaktGefunden = true;
                }
            }

            if (!kontaktGefunden)
            {
                Console.WriteLine("Kein Kontakt mit diesem Namen gefunden.");
            }
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Kontaktverwaltung ---");
                Console.WriteLine("1. Kontakt hinzufügen");
                Console.WriteLine("2. Kontakte anzeigen");
                Console.WriteLine("3. Kontakt suchen");
                Console.WriteLine("4. Programm beenden");
                Console.Write("Wählen Sie eine Option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        KontaktHinzufuegen();
                        break;

                    case "2":
                        KontakteAnzeigen();
                        break;

                    case "3":
                        KontaktSuchen();
                        break;

                    case "4":
                        return; // Programm beenden
                    default:
                        Console.WriteLine("Ungültige Option. Bitte erneut versuchen.");
                        break;
                }
            }
        }
    }
}