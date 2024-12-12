namespace Aufgabe03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person[] personen = null;
            ReadData(ref personen);

            foreach (Person p in personen)
            {
                Console.WriteLine($"{p.GetName()} ist {p.GetAlter()} Jahre alt");
            }

            double avg = CalculateAvg(personen);

            Console.WriteLine($"Das Durchschnittliche Alter beträgt {avg} Jahre");
        }

        public static void ReadData(ref Person[] personen)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "Personen.txt");

            string[] lines = File.ReadAllLines(filePath);
            personen = new Person[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(":");
                personen[i] = new Person(split[0], split[1]);
            }
        }

        public static double CalculateAvg(Person[] personen)
        {
            int sum = 0;

            for (int i = 0; i < personen.Length; i++)
            {
                sum += personen[i].GetAlter();
            }

            return sum / personen.Length;
        }
    }
}