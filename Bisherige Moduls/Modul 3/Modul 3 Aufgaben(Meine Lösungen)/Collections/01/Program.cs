using System.Net.WebSockets;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"write 10 satz { i+1 } te stelle;");
                string input = Console.ReadLine();
                queue.Enqueue(input);
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "output.txt");
            File.WriteAllLines(filePath, queue);
            Console.WriteLine();
            Console.WriteLine($"Die Zeilen wurden in '{filePath}' gespeichert.");
            Console.WriteLine();
            Console.WriteLine("queue contents:");
            Console.WriteLine();
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}