
namespace _06__
{
    internal class Program
    {
        public static string ReadNameFromUser()
        {
            Console.WriteLine("write your name");
            return Console.ReadLine();
        }
        public static void PrintGreeting(string name)
        {
            Console.WriteLine($"hi {name} du siehst gut aus");
        }
        static void Main(string[] args)
        {
            string name = ReadNameFromUser();
            PrintGreeting(name);
        }
    }
}