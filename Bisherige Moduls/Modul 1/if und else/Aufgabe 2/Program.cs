namespace Aufgabe_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //ask a Input(Nummber)
            Console.WriteLine("hi pl write a num");
            string NumText = Console.ReadLine();


            //change InputFormat in integer
            int Num = 0;
            int.TryParse(NumText, out Num);


            //check nummber for gerade or Ungerade
            if (Num % 2 == 0)
            {
                Console.WriteLine("dein zahl ist gerade");
            }
            else
            {
                Console.WriteLine("dein zahl war ungerade");
            }
        }
    }
}