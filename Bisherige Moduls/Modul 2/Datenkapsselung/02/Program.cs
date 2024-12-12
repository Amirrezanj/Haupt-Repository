namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mensch amir =new Mensch();
            amir.SetName("amir");
            amir.SetAlter(28);


            Console.WriteLine(amir.Vorstellen());
            Console.WriteLine(amir.Vorstellen());
            Console.WriteLine(amir.Geburstag());
            Console.WriteLine(DateTime.Now);



        }
    }
}