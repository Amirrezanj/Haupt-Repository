namespace _06
{
    internal class Program
    {
        private static string ReadNameFromUser()
        {
            Console.Write("dein name bitte ");
            
            return Console.ReadLine();
        }

        private static void PrintGreeting(string name)
        {
            Console.WriteLine($"Hallo {name}, du siehst gut aus!");
        }

        private static void Main()
        {
            string name = ReadNameFromUser();
            PrintGreeting(name);
        }

        
    }
}
