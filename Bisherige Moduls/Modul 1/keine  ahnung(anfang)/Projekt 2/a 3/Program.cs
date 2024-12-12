namespace a_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("pl write your number");
            string UserInputString = Console.ReadLine();
            
            int IntNumber = 0;
            int.TryParse(UserInputString, out IntNumber);

            float FloatNumber = 0;
            float.TryParse(UserInputString, out FloatNumber);
            


            Console.WriteLine(IntNumber + "--" +FloatNumber );
        }
    }
}
