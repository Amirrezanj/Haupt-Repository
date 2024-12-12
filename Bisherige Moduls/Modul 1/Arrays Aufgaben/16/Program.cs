namespace _16
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 ,20,25,33}; 
            
            int lastnum = arr[arr.Length - 1];

            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[0] = lastnum;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
        }
    }
}