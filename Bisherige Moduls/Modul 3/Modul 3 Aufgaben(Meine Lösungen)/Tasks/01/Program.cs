namespace testt
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string desktop=Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string directorypath = Path.Combine(desktop, "tst");
            List<Task> tasks = new List<Task>();
            foreach (var folder in Directory.EnumerateFiles(directorypath,"*.txt"))
            {
                tasks.Add(Task.Run(() => countInFile(folder)));
            }
        }
        private static void countInFile(string filpath)
        {
            FileInfo fi = new FileInfo(filpath);
            string txt = File.ReadAllText(fi.FullName);
            Dictionary<char, int> frequencyTable = new Dictionary<char, int>();
            foreach (char c in txt)
            {
                if (char.IsLetter(c))
                {
                    char lowerChar = char.ToLower(c);
                    if (frequencyTable.ContainsKey(lowerChar))
                    {
                        frequencyTable[lowerChar]++;
                    }
                    else
                    {
                        frequencyTable[lowerChar] = 1;
                    }
                }
            }
            Console.WriteLine($"sind : {filpath}:");
            foreach (var pair in frequencyTable)
            {
                Console.WriteLine($"{pair.Key}---{pair.Value}");
            }
            string output = Path.ChangeExtension(e.FullPath, ".freq");
            using (StreamWriter writer = new StreamWriter(output))
            {
                foreach (var pair in frequencyTable)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }
            Console.WriteLine($"in der Datei {output} gespeichert.");
        }
    }
}


wenn es passt würde ich gerne weiter schicken





















//namespace testt
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            string directoryPath = @"C:\Texte";

//            // Überprüfen, ob das Verzeichnis existiert. Wenn nicht, wird es erstellt.
//            if (!Directory.Exists(directoryPath))
//            {
//                Directory.CreateDirectory(directoryPath);
//            }
//            else
//            {
//                Console.WriteLine($"Verzeichnis existiert bereits.");
//            }

//            // Watcher, der auf neue Dateien im Verzeichnis achtet.
//            FileSystemWatcher watcher = new FileSystemWatcher(directoryPath)
//            {
//                EnableRaisingEvents = true,
//                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
//            };

//            // Ereignis, das ausgelöst wird, wenn eine neue Datei erstellt wird.
//            watcher.Created += Watcher_Created;

//            // Warten, damit das Programm weiterläuft und den FileSystemWatcher beobachtet.
//            Console.WriteLine("Warte auf neue Dateien...");
//            Console.ReadKey();
//        }

//        // Methode, die aufgerufen wird, wenn eine neue Datei im überwachten Verzeichnis erstellt wird.
//        private static void Watcher_Created(object sender, FileSystemEventArgs e)
//        {
//            // Für jede Datei wird ein Task gestartet, der die Häufigkeit der Buchstaben berechnet.
//            Task.Run(() => Rechnen(e.FullPath));
//        }

//        // Methode, die die Buchstabenhäufigkeit für eine gegebene Datei berechnet.
//        private static void Rechnen(string filePath)
//        {
//            // Sicherstellen, dass die Datei existiert
//            if (!File.Exists(filePath)) return;

//            // Den gesamten Inhalt der Datei lesen
//            string txt = File.ReadAllText(filePath);

//            // Häufigkeit der Buchstaben in einem Dictionary speichern
//            Dictionary<char, int> frequencyTable = new Dictionary<char, int>();
//            foreach (char c in txt)
//            {
//                // Nur Buchstaben zählen (Ignoriert Zahlen und Sonderzeichen)
//                if (char.IsLetter(c))
//                {
//                    // Alle Buchstaben in Kleinbuchstaben umwandeln (case insensitive)
//                    char lowerChar = char.ToLower(c);
//                    if (frequencyTable.ContainsKey(lowerChar))
//                    {
//                        frequencyTable[lowerChar]++;
//                    }
//                    else
//                    {
//                        frequencyTable[lowerChar] = 1;
//                    }
//                }
//            }

//            // Ausgabe auf der Konsole
//            Console.WriteLine($"In der Datei {filePath}:");
//            foreach (var pair in frequencyTable)
//            {
//                Console.WriteLine($"{pair.Key}: {pair.Value}");
//            }

//            // Die Häufigkeit in einer neuen Datei mit der Endung .freq speichern
//            string output = Path.ChangeExtension(filePath, ".freq");
//            using (StreamWriter writer = new StreamWriter(output))
//            {
//                foreach (var pair in frequencyTable)
//                {
//                    writer.WriteLine($"{pair.Key}: {pair.Value}");
//                }
//            }

//            Console.WriteLine($"Häufigkeit in {output} gespeichert.");
//        }
//    }
//}
