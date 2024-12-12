namespace Aufgabe27
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            int numberToFind = 13;
            int indexNumberFoundAt = -1;

            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (arr[middle] == numberToFind)
                {
                    indexNumberFoundAt = middle;
                    break;
                }

                if (arr[middle] < numberToFind)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            if (indexNumberFoundAt != -1)
            {
                Console.WriteLine("Die Zahl " + numberToFind + " wurde an der Stelle " + (indexNumberFoundAt + 1) + " gefunden.");
            }
            else
            {
                Console.WriteLine("Die Zahl " + numberToFind + " wurde nicht gefunden.");
            }
        }
    }
}