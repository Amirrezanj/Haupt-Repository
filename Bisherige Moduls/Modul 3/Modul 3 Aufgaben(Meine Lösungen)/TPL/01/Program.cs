using System.Collections.Concurrent;
namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\ITAD2-TN15\Desktop\Modul3-Aufgabe\Bisherige Moduls";
            string suchwort = "string";
            var files = Directory.EnumerateFiles(directoryPath, "*.cs", SearchOption.AllDirectories);

            ConcurrentStack<string> gefundene = new ConcurrentStack<string>();
            Parallel.ForEach(files, (file) =>
            {
                string text = File.ReadAllText(file);
                if (text.Contains(suchwort))
                {
                    gefundene.Push(file);
                    Console.WriteLine(file);
                }
            });
        }
    }
}