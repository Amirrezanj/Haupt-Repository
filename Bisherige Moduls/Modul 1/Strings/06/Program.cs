namespace _06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eingabe = "";
       
            while (eingabe.Length!=10)
            {
                Console.WriteLine("write a kennwort(10 zeichen)");
                eingabe = Console.ReadLine();
                eingabe = eingabe.Trim();
                Console.WriteLine((10-eingabe.Length)+" zeichen zu wenig");
            }
            if (eingabe.Length == 10)
            {
                Console.WriteLine("ok wird gespeichert");
            }
        }
    }
}
