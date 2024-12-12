namespace _11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string satz = "Amir";
            
            //char[] zeichenchar = satz.ToCharArray();
            char[] zeichenchar = new char[satz.Length];
            for (int i =0;i<satz.Length;i++)
            {
                zeichenchar[i]=satz[i];
            }


            for (int i = 0; i < zeichenchar.Length ; i++)
            {
                
                int numberchar = zeichenchar[i];
                Console.Write(numberchar+" ");
            }
        }
    }
}
