using System.IO;

namespace _01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string? filepath = null;
            while (true)
            {
                Console.WriteLine("plese write name of file");
                string eingabe = Console.ReadLine()!;
                filepath = SearchFileInAllDrives(eingabe)!;

                if (filepath != null)
                {
                    Console.WriteLine($"Datei gefunden: {filepath}");
                    break;
                }
                else
                {
                    Console.WriteLine("Datei nicht gefunden. Bitte geben Sie einen anderen Dateinamen ein.");
                }
                break;
            }

            FileStream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter writer = new StreamWriter(stream);

            Console.WriteLine("bitte ein text mit ein . am ende éingebn");

            while (true)
            {
                string eingabe2 = Console.ReadLine()!;
                string timestamped = $"{DateTime.Now} - {eingabe2}";
                writer.WriteLine(timestamped);
                Console.WriteLine($"Geschrieben: {timestamped}");
                if (eingabe2.Contains("."))
                {
                    Console.WriteLine(" eingabe eingegebn ");
                    break;
                }
            }
        }

        private static string? SearchFileInAllDrives(string fileName)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                if (!drive.IsReady)
                {
                    Console.WriteLine($"Laufwerk {drive.Name} ist nicht bereit.");
                    continue;
                }
                try
                {
                    Console.WriteLine($"Durchsuche Laufwerk: {drive.Name}");
                    string? foundFile = SearchFileInDirectory(new DirectoryInfo(drive.Name), fileName);
                    if (foundFile != null)

                        return foundFile;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Zugriff nicht möglich");
                }
            }

            return null;
        }

        private static string? SearchFileInDirectory(DirectoryInfo directory, string fileName)
        {
            try
            {
                foreach (var file in directory.GetFiles())
                {
                    if (file.Name.Equals(fileName))
                    {
                        return file.FullName;
                    }
                }
                foreach (var dir in directory.GetDirectories())
                {
                    string foundFile = SearchFileInDirectory(dir, fileName)!;
                    if (foundFile != null)

                        return foundFile;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("nicht gefunden");
            }
            
            return null;
        }
    }
}