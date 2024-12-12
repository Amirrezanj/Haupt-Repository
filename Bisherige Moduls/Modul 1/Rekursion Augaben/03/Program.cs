namespace _03
{
    internal class Program
    {
        public static int Ggt(int n1, int n2)
        {
            //basis fall
            if (n2 == 0) return n1;
            return Ggt(n2, n1 % n2);

        }
        static void Main(string[] args)
        {
            Console.WriteLine("write a number");
            int eingabe1 = int.Parse(Console.ReadLine());
            Console.WriteLine("write a number");
            int eingabe2 = int.Parse(Console.ReadLine());
            int GGT = Ggt(eingabe1, eingabe2);
            Console.WriteLine("GGT ist " + GGT);

        }
    }
}
