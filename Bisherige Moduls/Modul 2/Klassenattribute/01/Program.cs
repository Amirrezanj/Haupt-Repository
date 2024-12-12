namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("amir");
            Player player2 = new Player("tasos");

            player1.Gamble();
            player2.Gamble();

            Console.WriteLine($"{player1.GetName()} hat insgesamt {player1.GetScore()} punkte.");
            Console.WriteLine($"{player2.GetName()} hat insgesamt {player2.GetScore()} punkte.");
        }
    }
}
