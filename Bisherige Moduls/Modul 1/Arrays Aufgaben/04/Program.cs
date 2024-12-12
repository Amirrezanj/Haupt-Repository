namespace _04
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hi pl write länge des arrays");
            Console.Write("and i give you Random Nummbers");
            string abfragetext = Console.ReadLine();
            int.TryParse(abfragetext, out int abfrage);
            int[] arr = new int[abfrage];
            int summe = 0;

            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 101);
                Console.WriteLine(arr[i]);
                //summe = arr[i] + summe;
                summe += arr[i];
            }

            Console.WriteLine("Und die Summe ist " + summe);
        }
    }
}