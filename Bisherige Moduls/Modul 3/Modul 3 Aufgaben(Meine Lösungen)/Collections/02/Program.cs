namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "output.txt");
            string[] lines = File.ReadAllLines(filePath);

            var dictionary = new Dictionary<string, int>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(" ");
                for (int j = 0; j < words.Length; j++)
                {
                    //string klein = words[j].ToLower();
                    if (dictionary.ContainsKey(words[j]))
                    {
                        dictionary[words[j]]++;
                    }
                    else
                    {
                        dictionary.Add(words[j], 1);
                    }                   
                }
            }
            foreach (var s in dictionary)
            {
                Console.WriteLine(s.Key+" "+s.Value);
            }
        }
    }
}