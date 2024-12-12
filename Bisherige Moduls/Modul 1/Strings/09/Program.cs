namespace _09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("write a string: ");
            string eingabe = Console.ReadLine();
            char[] zeichen = new char[eingabe.Length];

            for (int i = 0; i < eingabe.Length; i++)
            {
                zeichen[i] = eingabe[i];
            }
            //char[] zeichen = eingabe.ToCharArray();

            for (int i = 0; i < zeichen.Length - 1; i += 2)
            {
                char temp = zeichen[i];
                zeichen[i] = zeichen[i + 1];
                zeichen[i + 1] = temp;
            }

            string neu = new string(zeichen);

            Console.WriteLine("verschlüselte form : " + neu);

        }
    }
}