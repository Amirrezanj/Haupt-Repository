namespace _25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr= {1,2,3,4,5};
            int choseNumber = 1;
            int gefundenPlatz = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == choseNumber)
                {
                    gefundenPlatz= i;
                    break;
                }
            }
            if (gefundenPlatz != -1)
            {
                Console.WriteLine(choseNumber+" wurde an "+gefundenPlatz+1 +" platz gefundem");
            }
            else
            {
                Console.WriteLine("nicht gefunden");
            }


        }
    }
}
