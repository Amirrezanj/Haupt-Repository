using System.Globalization;

namespace _06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vector3 vector1;
            //vector1.x = 1;
            //vector1.y = 2;
            //vector1.z = 3;


            //vector3 vector2;
            //vector2.x = 4;
            //vector2.y = 5;
            //vector2.z = 6;


            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "vector3.csv");

            string[] lines = File.ReadAllLines(filePath);

            vector3[] vectors = new vector3[lines.Length - 1];

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                double a = double.Parse(parts[0],CultureInfo.InvariantCulture);
                double b = double.Parse(parts[1], CultureInfo.InvariantCulture);
                double c = double.Parse(parts[2], CultureInfo.InvariantCulture);
                vectors[i-1].x = a;
                vectors[i-1].y = b;
                vectors[i-1].z = c;
            }
            for (int i = 0; i < vectors.Length; i++)
            {
                Console.WriteLine(vectors[i].AsString());
            }
            
        }
    }
}