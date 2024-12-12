namespace _06
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 ,6};
            Console.WriteLine($"Die Summe ist: {ArraySum(array)}");
        }
        static int ArraySum(int[] array, int index=0)
        {
            if (index == array.Length)
                return 0;

            return array[index] + ArraySum(array, index + 1);
        }
       
    }
}