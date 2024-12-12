namespace Aufgabe24
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = { 6, 3, 7, 2, 8, 1 };

            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            foreach (int value in arr)
            {
                Console.WriteLine(value + " ");
            }
        }
    }
}