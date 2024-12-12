namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("write a satz");
            string eingabe = Console.ReadLine();

            int vokal = 0;

            foreach (char c in eingabe)
            {
                if ("aeiouAEIOU".Contains(c))
                {
                    vokal++;
                }
            }
            Console.WriteLine("insgesamt "+vokal+" vokale");



        }
    }
}