namespace _04
{
    internal class Program
    {
        public static int GetMaxNumber(int x, int y)
        {


            if (x>y)
            {
                return x;
            }
            else 
            {
                return y;
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine("first number");
            string eingabe1Text = Console.ReadLine();
            int.TryParse(eingabe1Text, out int x);

            Console.WriteLine("second number");
            string eingabe2Text = Console.ReadLine();
            int.TryParse(eingabe2Text, out int y);
            
            Console.WriteLine(GetMaxNumber(x,y));
        }
    }
}
