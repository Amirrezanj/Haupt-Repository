using System.IO;

namespace _6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktop= Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderpath = Path.Combine(desktop, "AE");
            //1
            DirectoryInfo directoryInfo = new DirectoryInfo(folderpath);
            foreach (var file in directoryInfo.GetFiles().OrderByDescending(x=>x.Name))
            {
                Console.Write($"{file.Name} ,");
            }
            Console.WriteLine();
            //2
            foreach (var file in directoryInfo.GetFiles().OrderByDescending(x => x.Length))
            {
                Console.Write($"{file.Name} ,");

            }
            Console.WriteLine();
            //3
            foreach (var file in directoryInfo.GetFiles().OrderByDescending(x => x.LastAccessTime))
            {
                Console.Write($"{file.Name} ,");

            }
            Console.WriteLine();

        }
    }
}
