namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //folder
            string backupFolderPath = Path.Combine(desktopPath, "Backup");
            Directory.CreateDirectory(backupFolderPath);


            string oldFolderPath = Path.Combine(desktopPath, "TestFolder");



            //File
            string oldfilePath = Path.Combine(oldFolderPath, "example.txt");


            string backupfilePath = Path.Combine(backupFolderPath, "example.txt");

            File.Copy(oldfilePath,backupfilePath );

            if (File.Exists(backupfilePath))
            {
                Console.WriteLine("Datei existiert");
                File.Delete(oldfilePath);
            }
            else
            {
                Console.WriteLine("Datei existiert nicht");
            }
        }
    }
}