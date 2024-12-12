namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boxer player1 = new Boxer("amir", 10);
            Boxer player2 = new Boxer("tasos");

            while (player1.GetVitalitaet() > 0 && player2.GetVitalitaet() > 0)
            {
                player1.Schlagen(player2);
                if (player2.GetVitalitaet() <= 0)
                {
                    Console.WriteLine($"{player2.GetName()} ist K.O");
                    break;
                }
                player2.Schlagen(player1);
                if (player1.GetVitalitaet() <= 0)
                {
                    Console.WriteLine($"{player1.GetName()} ist K.O");
                    break;
                }
            }

        }
    }
}