using System.IO;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "MyFiles");
            Directory.CreateDirectory(folderPath);

            string filePath1=Path.Combine(folderPath,"document1.txt");
            string filePath2=Path.Combine(folderPath,"document2.txt");
            string filePath3=Path.Combine(folderPath,"document3.txt");

            Console.WriteLine($"Filename: {Path.GetFileName(filePath1)}");
            Console.WriteLine($"Extension: {Path.GetExtension(filePath1)}");
            Console.WriteLine();

            Console.WriteLine($"Filename: {Path.GetFileName(filePath2)}");
            Console.WriteLine($"Extension: {Path.GetExtension(filePath2)}");
            Console.WriteLine();

            Console.WriteLine($"Filename: {Path.GetFileName(filePath3)}");
            Console.WriteLine($"Extension: {Path.GetExtension(filePath3)}");
        }
    }
}