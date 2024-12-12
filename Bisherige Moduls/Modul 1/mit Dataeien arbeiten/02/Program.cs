using System.IO;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string filePath = Path.Combine(desktopPath, "TestFolder", "example.txt");
            string text = File.ReadAllText(filePath);
            Console.WriteLine(text);

            File.AppendAllText(filePath, "this is a newline");
            text = File.ReadAllText(filePath);
            Console.WriteLine(text);


        }
    }
}