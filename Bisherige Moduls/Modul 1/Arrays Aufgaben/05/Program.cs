namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]arr = {0,1,2,3,4,5};
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (i + i + 2);
                Console.WriteLine(arr[i]);
            }
            
        }
    }
}
