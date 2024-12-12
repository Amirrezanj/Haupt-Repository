namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] arr1 = new int[5];
            arr1 [0] = 0;
            arr1 [1] = 1;
            arr1 [2] = 2;
            arr1 [3] = 3;
            arr1 [4] = 4;


            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i]);
            }
            //Console.WriteLine(arr1[0] + "   " + arr1[1]+"");
        }
    }
}
