namespace _13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] arr = {1,2,3,2,1,6,7,8,10};
            bool issort = true;
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] < arr[i+1])
                {
                    issort = true;
                    
                }
                else
                {
                    issort = false;
                    break;
                }
            }
            Console.WriteLine(issort);
        }
    }
}

