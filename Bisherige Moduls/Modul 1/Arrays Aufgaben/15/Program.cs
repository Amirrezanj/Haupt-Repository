namespace _15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            bool hoch = true; 

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    hoch = true;

                }
                else if (arr[i] > arr[i + 1])
                {
                    hoch = false;
                    break;
                }
            }
            if (hoch)
            {
                Console.WriteLine("aufgestiegen");
            }
            else
            {
                Console.WriteLine("abgestiegen");
            }
        }
    }
}
