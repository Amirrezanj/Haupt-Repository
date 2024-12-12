namespace _12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1,2,3,4,5,6,7,8,9};

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    arr[i] = arr[i]/2;
                }
                else if (arr[i]%2==1)
                {
                    arr[i] = arr[i] * 2;
                }
                Console.WriteLine(arr[i]);
            }

        }
    }
}
