namespace _10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] zahlen = { 1, 2, 3, 4, 5 };
            int temp = 0;
            for (int i = 0; i < zahlen.Length /2; i++)
            {

                temp = zahlen[i];
                zahlen[i] = zahlen[zahlen.Length -1 - i];
                zahlen[zahlen.Length-1 - i] = temp;
                
            }

            for (int i = 0; i < zahlen.Length; i++)
            {
                Console.WriteLine(zahlen[i]);               
            }

        }
        
    }
}
