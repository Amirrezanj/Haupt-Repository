using static System.Net.Mime.MediaTypeNames;

namespace _14
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
                Console.WriteLine($"falsche eingabe bitte zwichen {min} und {max} ");
                eingabetext = Console.ReadLine();
                success = int.TryParse(eingabetext, out eingabe);
            }
            return eingabe;
        }

        public static void FillArrayWithRandomNumbers(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Random random = new Random();
                array[i] = random.Next(1, 100);
            }
        }

        public static int Sum(int[] array)
        {
            int summe = 0;
            for (int i = 0; i < array.Length; i++)
            {
                summe += array[i];
            }
            return summe;
        }

        public static double Avg(int[] array)
        {
            double avg = 0;
            for (int i = 0; i < array.Length; i++)
            {
                avg = Sum(array) / array.Length;
            }
            return avg;
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        private static void Main(string[] args)
        {
            int usereingabe = ReadNumberFromUser("write a number from 1 , 100", 1, 100);
            int[] randomzahlen = new int[usereingabe];
            FillArrayWithRandomNumbers(randomzahlen);
            PrintArray(randomzahlen);
            int summe = Sum(randomzahlen);
            Console.WriteLine("die summe ist " + summe);
            double avg = Avg(randomzahlen);
            Console.WriteLine("avg ist " + avg);
        }
    }
}