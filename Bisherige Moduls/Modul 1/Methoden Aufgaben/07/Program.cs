namespace _07
{
    internal class Program
    {
        
        public static string ReadAgeFromUser()
        {
            Console.WriteLine("write your age");
            return Console.ReadLine();
            
        }
        public static string ReadNameFromUser()
        {
            Console.WriteLine("write your name");
            return Console.ReadLine();
        }
        public static void PrintGreeting(string name,string age)
        {
            Console.WriteLine($"hi {name} bei {age} siehst gut aus");
        }
        static void Main(string[] args)
        {
            string ag = ReadAgeFromUser();
            string nam = ReadNameFromUser();
            PrintGreeting(nam,ag);
        }
    }
}