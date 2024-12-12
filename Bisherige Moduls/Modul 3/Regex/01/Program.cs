using System.Text.RegularExpressions;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath1 = Path.Combine(desktop, "Frosch.txt");
            string[] lines = File.ReadAllLines(filePath1);

            int umlaut = 0;
            int der= 0;
            int größbuchstaben= 0;
            int frosch=0;
            int pnktamende = 0;
            int ßamende= 0;
            int anfangende = 0;
            int dreibuchstaben = 0;
            int derdiedas = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (Regex.IsMatch(line,@"[ÄäÖöÜü]"))
                {
                    umlaut++;
                    Console.WriteLine(lines[i]);
                }
                if (Regex.IsMatch(line,@"\b(der)\b"))
                {
                    der++;
                }
                if (Regex.IsMatch(line, @"^[A-Z]"))
                {
                    größbuchstaben++;
                }
                if (Regex.IsMatch(line, @"\b(Frosch|Froschkönig)\b"))
                {
                    frosch++;
                }
                if (Regex.IsMatch(line, @"\.$"))
                {
                    pnktamende++;
                }
                if (Regex.IsMatch(line, @"\w*ß"))
                {
                    ßamende++;
                    
                }
                if (Regex.IsMatch(line, @"^\s*$"))
                {
                    anfangende++;
                }
            }
            Console.WriteLine("gefundene zeilen indem umlaut sind : "+umlaut);
            Console.WriteLine("gefundene zelien indem (der) alein steht : "+der);
            Console.WriteLine("gefundene zeilen mit Größbuchstaben Anfang : "+größbuchstaben);
            Console.WriteLine("gefundene zeilen indem Fösch und fröschkönig stehen sind : "+frosch);
            Console.WriteLine("gefundene zeilen mit punkt am ende sind : "+pnktamende);
            Console.WriteLine("gefundene zeilen mit ß am ende sind : "+ ßamende);
            Console.WriteLine("gefundene zeilen die leer sind : "+anfangende);

        }
    }
    
}
