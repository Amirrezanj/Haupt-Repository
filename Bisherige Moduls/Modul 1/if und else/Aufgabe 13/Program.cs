namespace Aufgabe_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string EingabeText = Console.ReadLine();
            int Eingabe = 0;
            int.TryParse(EingabeText, out Eingabe);

            for (int i = 1;i<=100 ; i++) 
            {
                Console.Write(i+" X "+Eingabe+" = "+ i*Eingabe+"  ,  ");
            }
        }
    }
}
