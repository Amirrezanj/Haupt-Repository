namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PiggyBank gholak=new PiggyBank(10);
            gholak.shake();
            gholak.Add1euro(2);
            gholak.shake();
            gholak.Add1Cent(6);
            gholak.shake();
            gholak.Add1Cent(3);
            Console.WriteLine(gholak.IsBrocken());
            gholak.shake();
            gholak.Breackinto();

        }
    }
}
