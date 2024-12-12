namespace _13
{
    internal class Program
    {
        public static int ReadNumberFromUser(string text, int min, int max)
        {
            Console.WriteLine(text);
            string eingabetext = Console.ReadLine();
            bool success = int.TryParse(eingabetext, out int eingabe);
            while (!success || eingabe < min || eingabe > max)
            {
                Console.WriteLine($"Ungültige Eingabe , Zahl zwischen {min} und {max} ");
                eingabetext = Console.ReadLine();
                success = int.TryParse(eingabetext, out eingabe);
            }
            return eingabe;
        }

        public static int[] ReadInArray(int numOfElements)
        {
            int[] array = new int[numOfElements];

            for (int i = 0; i < numOfElements; i++)
            {
                array[i] = ReadNumberFromUser($"geben Sie Zahl {i + 1} ein: ", 1, 20);
            }

            return array;
        }

        public static int FindMin(int[] searchArray)
        {
            int min = searchArray[0];
            for (int i = 1; i < searchArray.Length; i++)
            {
                if (searchArray[i] < min)
                {
                    min = searchArray[i];
                }
            }
            return min;
        }

        public static int FindMax(int[] searchArray)
        {
            int max = searchArray[0];
            for (int i = 1; i < searchArray.Length; i++)
            {
                if (searchArray[i] > max)
                {
                    max = searchArray[i];
                }
            }
            return max;
        }

        private static void Main(string[] args)
        {
            int wieViel = ReadNumberFromUser("schreiben sie wie viele nummer?", 1, 20);
            int[] zahlen = ReadInArray(wieViel);
            int min = FindMin(zahlen);
            int max = FindMax(zahlen);
            Console.WriteLine("min ist "+min+" max ist "+max);

        }
    }
}