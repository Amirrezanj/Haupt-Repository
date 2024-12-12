namespace _13
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("screiben sie ein satz in form name=wert");
            string eingabe = Console.ReadLine();
            eingabe = eingabe.Trim();



            if (eingabe.Contains("=") )
            {
                
                string[] eingabearray = eingabe.Split('=');

                if (eingabearray[0] != "")
                {
                    if (eingabearray.Length == 2)
                    {
                        Console.WriteLine("name is " + eingabearray[0]);
                        Console.WriteLine("wert is " + eingabearray[1]);
                        Console.WriteLine("länge des satz ist " + (eingabearray[0].Length + eingabearray[1].Length + 1));

                    }
                }
                else 
                {
                    Console.WriteLine("fält die name");
                }
            }
            else
            {
                Console.WriteLine(" = fählt");
            }
        }
    }
}