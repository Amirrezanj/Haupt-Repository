namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socke mainsocke= new Socke();
            mainsocke.SetFarbe("grün");
            mainsocke.Wasche();
            Console.WriteLine(mainsocke.Ausgabe());
            mainsocke.Trockene();
            Console.WriteLine(mainsocke.Ausgabe());
            mainsocke.SetFarbe("blau");
            Console.WriteLine(mainsocke.Ausgabe());



            Socke mainsocke2 = new Socke();
            Console.WriteLine(mainsocke2.Ausgabe());
            mainsocke2.Wasche();
            Console.WriteLine(mainsocke2.Ausgabe());
            mainsocke2 .Trockene();
            Console.WriteLine(mainsocke2.Ausgabe());



            Socke mainsocke3 = new Socke();
            Console.WriteLine(mainsocke3.Ausgabe());
            mainsocke3.Wasche();
            Console.WriteLine(mainsocke3.Ausgabe());
            mainsocke3 .Trockene();
            mainsocke3.SetFarbe("black");
            Console.WriteLine(mainsocke3.Ausgabe());
            
        }
    }
}
