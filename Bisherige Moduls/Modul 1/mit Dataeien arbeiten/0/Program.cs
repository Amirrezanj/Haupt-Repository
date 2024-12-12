namespace _0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //folder
            string folderPath = Path.Combine(desktopPath, "TestFolder");
            Directory.CreateDirectory(folderPath);

            //file
            string filePath = Path.Combine(folderPath, "example.txt");
            File.WriteAllText(filePath, "Hello World");

            //ob es exists
            bool fileExists = File.Exists(filePath);
            Console.WriteLine(fileExists);
        }
    }
}