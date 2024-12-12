namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] arr =new int[10];
            int i ;
            for (i=1; i<arr.Length ; i++)
            {
                if (i % 2 == 0)
                {
                    arr[i] = i;
                }
            }
            for (i = 1; i < arr.Length; i++)
            {
                if (i % 2 != 0)
                {
                    arr[i] = i;
                }

            }
            for (i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }


        }
    }
}
