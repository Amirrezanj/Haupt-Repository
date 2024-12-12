//using System.Net;

//namespace _03
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            string directoryPath = @"C:\Lookup";
//        }
//    }
//}


















using System;
using System.IO;
using System.Net;

namespace LookupWatcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string directoryPath = @"C:\Lookup"; // Ändern Sie dies bei Bedarf auf "C:\Lookup"

            // Überprüfen, ob das Verzeichnis existiert
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Das Verzeichnis '{directoryPath}' existiert nicht. Erstellen Sie es zuerst.");
                return;
            }

            Console.WriteLine($"Überwache Verzeichnis: {directoryPath}");

            FileSystemWatcher watcher = new FileSystemWatcher(directoryPath, "*.lookup")
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };

            // Event-Handler einrichten
            watcher.Created += OnNewLookupFile;

            // Überwachung starten
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Drücken Sie eine beliebige Taste, um das Programm zu beenden.");
            Console.ReadKey();
        }

        private static void OnNewLookupFile(object sender, FileSystemEventArgs e)
        {
            try
            {
                string inputFilePath = e.FullPath;
                Console.WriteLine($"Neue Datei gefunden: {inputFilePath}");

                string outputFilePath = Path.ChangeExtension(inputFilePath, ".resolved");

                // Datei lesen und verarbeiten
                string[] fqdnList = File.ReadAllLines(inputFilePath);
                using StreamWriter writer = new StreamWriter(outputFilePath);

                foreach (string fqdn in fqdnList)
                {
                    if (!string.IsNullOrWhiteSpace(fqdn))
                    {
                        try
                        {
                            // DNS-Abfrage
                            IPAddress[] addresses = Dns.GetHostAddresses(fqdn);
                            writer.WriteLine($"FQDN: {fqdn}");
                            foreach (var address in addresses)
                            {
                                writer.WriteLine($"  - {address}");
                            }
                        }
                        catch (Exception ex)
                        {
                            writer.WriteLine($"FQDN: {fqdn} - Fehler: {ex.Message}");
                        }
                    }
                }

                Console.WriteLine($"Ergebnis in Datei geschrieben: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Verarbeiten der Datei {e.FullPath}: {ex.Message}");
            }
        }
    }
}
