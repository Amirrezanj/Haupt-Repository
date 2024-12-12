namespace testt
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string directoryPath = @"C:\Texte";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"{directoryPath} wurde erstellt");
            }
            else
            {
                Console.WriteLine($"habe ich shon!!!!");
            }
            FileSystemWatcher watcher = new FileSystemWatcher(directoryPath);
            watcher.Created += Watcher_Created;
            watcher.EnableRaisingEvents = true;
            Console.ReadKey();
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string txt = File.ReadAllText(e.FullPath);
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
            Console.WriteLine($"Buchstabenhäufigkeit für die Datei {e.FullPath}:");
            foreach (var pair in frequencyTable)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            string outputFilePath = Path.ChangeExtension(e.FullPath, ".freq");
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var pair in frequencyTable)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }

            Console.WriteLine($"Buchstabenhäufigkeit in der Datei {outputFilePath} gespeichert.");
        }
    }
}
