namespace _06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] boolian = [true , false ,false , true , true , false] ;
            
            for (int i = 0; i < boolian.Length; i++)
            {
                Console.Write(boolian[i]);
                if (boolian[i] == true)
                {
                    boolian[i] = false ;
                }
                else
                {
                    boolian[i] = true;
                }
                Console.Write(" -> "+boolian[i]);
            }

        }
    }
}
