namespace _14
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] array = { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10 };

            bool issorted = true;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    issorted = false;
                    break;
                }
            }
            Console.WriteLine(issorted);
           
        }
    }
}