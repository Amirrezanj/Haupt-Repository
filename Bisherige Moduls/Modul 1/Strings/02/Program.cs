namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eingabe = Console.ReadLine();

            //for (int i = 0; i < eingabe.Length; i++)
            //{
            //    Console.WriteLine(eingabe[i]);
            //}
            foreach (char value in eingabe)
            {
                Console.WriteLine(value);
            }

        }
    }
}








