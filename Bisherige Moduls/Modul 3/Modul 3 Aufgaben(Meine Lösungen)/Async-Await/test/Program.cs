namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1");
            DoSomthing();
            Console.WriteLine("5");
            Console.ReadLine();

        }
        public static async void DoSomthing()
        {
            Console.WriteLine("2");
            Console.WriteLine("3");
            await Task.Run(() => AndereMethode());
            Console.WriteLine("7");
        }
        public static void AndereMethode()
        {
            Console.WriteLine("4");
            Thread.Sleep(1000);
            Console.WriteLine("6");
        }
    }

}
