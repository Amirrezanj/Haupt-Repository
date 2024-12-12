namespace _05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string newFolderPath = Path.Combine(desktop, "logs");
            bool exist = Directory.Exists(newFolderPath);
            if (!exist)
            {
                Directory.CreateDirectory(newFolderPath);
                string filepath1 = Path.Combine(newFolderPath, "log1.txt");
                string filepath2 = Path.Combine(newFolderPath, "log2.txt");
                string filePath3 = Path.Combine(newFolderPath, "log3.txt");
                File.WriteAllText(filepath1, string.Empty);
                File.WriteAllText(filepath2, string.Empty);
                File.WriteAllText(filePath3, string.Empty);
                //for (int i = 0; i < 3; i++)
                //{
                //    string filePath = Path.Combine(newFolderPath, $"log{i}.txt");
                //    File.WriteAllText(filePath, string.Empty);
                //}

                string[] logFiles = Directory.GetFiles(newFolderPath);

                foreach (string logFile in logFiles)
                {
                    Console.WriteLine(logFile);
                }
            }
            else
            {
                Console.WriteLine("folder exist");
            }


        }
    }
}