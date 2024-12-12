namespace Aufgabe19
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Gib den zu verschlüsselnden Text ein: ");
            string input = Console.ReadLine();

            Console.Write("Um wie viele Stellen soll der Text verschlüsselt werden? ");
            int shift = int.Parse(Console.ReadLine());

            char[] encryptedArr = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    char offset = 'A';

                    if (char.IsLower(input[i]))
                    {
                        offset = 'a';
                    }

                    encryptedArr[i] = (char)((input[i] + shift - offset) % 26 + offset);
                }
                else
                {
                    encryptedArr[i] = input[i];
                }
            }

            string result = new string(encryptedArr);

            Console.WriteLine(result);
        }
    }
}