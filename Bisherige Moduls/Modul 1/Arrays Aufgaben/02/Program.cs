namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float[] arr1 = new float[5];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1 [i] = i;
                Console.WriteLine(arr1[i]);
            }
            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    Console.WriteLine(arr1[i]);
            //}
            
        }
    }
}
