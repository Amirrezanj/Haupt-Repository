namespace _03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string eingabe = Console.ReadLine();
            Console.WriteLine();

            string ueingabe = new string(eingabe);
            for (int i = eingabe.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(ueingabe[i]);
            }
        }
    }
}