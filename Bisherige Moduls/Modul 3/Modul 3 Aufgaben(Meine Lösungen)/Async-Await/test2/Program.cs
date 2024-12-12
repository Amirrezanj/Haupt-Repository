namespace test2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1");
            await DoSomthing();
            Console.WriteLine("finish");
            Console.ReadLine();
        }
        public static async Task DoSomthing()
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
