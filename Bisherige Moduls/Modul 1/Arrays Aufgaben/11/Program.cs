namespace _11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arr1 = { 10, 20, 30 };
            int[] arr2 = { 40, 50, 60 };
            int[] arr3 = new int[3];

            Console.WriteLine("erste array : ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i]+" ");
            }
            Console.WriteLine();


            Console.WriteLine("zweite array : ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr2[i]+" ");
            }
            Console.WriteLine();


            Console.WriteLine("dritte array : ");
            for (int i = 0; i < arr1.Length; i++)
            {
                arr3[i] = arr1[i] + arr2[i];
            }


            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr3[i]+" ");
            }
        }
    }
}
