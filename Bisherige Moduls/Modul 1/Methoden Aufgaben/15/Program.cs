//namespace _15
//{
//    internal class Program
//    {
//        public static int ReadNumberFromUser(string text, int min, int max)
//        {
//            Console.WriteLine(text);
//            string eingabetext = Console.ReadLine();
//            bool succes=int.TryParse(eingabetext, out int eingabe);
//            while (!succes||eingabe<min||eingabe>max)
//            {
//                Console.WriteLine("falsche eingabe");
//                eingabetext = Console.ReadLine();
//                succes = int.TryParse(eingabetext, out eingabe);
//            }
//            return eingabe;
//        }
//        public static int[] FillArrayWithRandomNumbers(int length, int min, int max)
//        {
//            //int minimum = ReadNumberFromUser("von (1-100)?", 1, 100);
//            //int maximum = ReadNumberFromUser("bis (1-100)?", 1, 100);
//            int leng= ReadNumberFromUser("wie viel zahlen(1,100)",1,100);
//            int[] array = new int[leng];
//            for (int i = 0; i < length; i++)
//            {
//                a
//            }
//        }

//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//        }
//    }
//}
using System;

namespace ZufallszahlenMitHäufigkeit
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int numOfElements = ReadNumberFromUser("Wie viele Zahlen möchten Sie im Array haben? (1 bis 100): ", 1, 100);

            int minRange = ReadNumberFromUser("Bitte geben Sie das Minimum des Zahlenbereichs ein: ", int.MinValue, int.MaxValue);
            int maxRange = ReadNumberFromUser("Bitte geben Sie das Maximum des Zahlenbereichs ein: ", minRange, int.MaxValue);

            int[] randomArray = FillArrayWithRandomNumbers(numOfElements, minRange, maxRange);

            int[,] frequency = GetFrequency(randomArray, minRange, maxRange);

            PrintResult(randomArray, frequency);
        }

        static int ReadNumberFromUser(string text, int min, int max)
        {
            int number;
            bool success;

            do
            {
                Console.Write(text);
                string input = Console.ReadLine();
                success = int.TryParse(input, out number);

                if (!success || number < min || number > max)
                {
                    Console.WriteLine($"Ungültige Eingabe. Bitte geben Sie eine Zahl zwischen {min} und {max} ein.");
                }

            } while (!success || number < min || number > max);

            return number;
        }

        static int[] FillArrayWithRandomNumbers(int length, int min, int max)
        {
            Random random = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(min, max + 1); 
            }
            return array;
        }

        static int[,] GetFrequency(int[] array, int min, int max)
        {
            int range = max - min + 1;
            int[,] frequency = new int[range, 2];

            for (int i = 0; i < range; i++)
            {
                frequency[i, 0] = min + i; 
                frequency[i, 1] = 0;       
            }

            
            foreach (int num in array)
            {
                int index = num - min;
                frequency[index, 1]++; 
            }

            return frequency;
        }

        static void PrintResult(int[] arr, int[,] frequency)
        {
            Console.WriteLine("\nDas Array enthält folgende Zahlen:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\n\nZahl \t Häufigkeit");
            for (int i = 0; i < frequency.GetLength(0); i++)
            {
                if (frequency[i, 1] > 0) 
                {
                    Console.WriteLine(frequency[i, 0] + " \t " + frequency[i, 1]);
                }
            }
        }
    }
}
