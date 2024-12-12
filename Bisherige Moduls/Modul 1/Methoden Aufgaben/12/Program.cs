using System;

namespace ZahlenErmittlung
{
    class Program
    {
        static void Main(string[] args)
        {
            // Frage den Benutzer, wie viele Zahlen er eingeben möchte (zwischen 1 und 20)
            int numOfElements = ReadNumberFromUser("Wie viele Zahlen möchten Sie eingeben? (1 bis 20): ", 1, 20);

            // Lese die Zahlen in ein Array ein
            int[] zahlen = ReadInArray(numOfElements);

            // Finde die kleinste und größte Zahl
            int min = FindMin(zahlen);
            int max = FindMax(zahlen);

            // Gib die kleinste und größte Zahl aus
            Console.WriteLine($"Die kleinste Zahl ist: {min}");
            Console.WriteLine($"Die größte Zahl ist: {max}");
        }

        static int ReadNumberFromUser(string text, int min, int max)
        {
            int zahl;
            bool success;

            do
            {
                Console.Write(text);
                string eingabe = Console.ReadLine();
                success = int.TryParse(eingabe, out zahl);

                if (!success || zahl < min || zahl > max)
                {
                    Console.WriteLine($"Ungültige Eingabe. Bitte eine Zahl zwischen {min} und {max} eingeben.");
                }

            } while (!success || zahl < min || zahl > max);

            return zahl;
        }

        static int[] ReadInArray(int numOfElements)
        {
            int[] array = new int[numOfElements];

            for (int i = 0; i < numOfElements; i++)
            {
                array[i] = ReadNumberFromUser($"Bitte geben Sie Zahl {i + 1} ein: ", 1, 20);
            }

            return array;
        }

        // Methode 3: Findet die kleinste Zahl im Array
        static int FindMin(int[] searchArray)
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

        // Methode 4: Findet die größte Zahl im Array
        static int FindMax(int[] searchArray)
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
    }
}
