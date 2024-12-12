namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("zeichenkete : ");
            string eingabe = Console.ReadLine();
            bool ispalindrom =true;
            for (int i = 0; i < eingabe.Length / 2; i++)
            {
                if (eingabe[i] != eingabe[eingabe.Length - 1- i])
                {
                    ispalindrom = false;
                    break;
                }
            }

            if (ispalindrom)
            {
                Console.WriteLine("palindrom.");
            }
            else
            {
                Console.WriteLine("kein Palindrom.");
            }


        }
    }
}