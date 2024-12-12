namespace _01
{
    public class Player
    {
        private int _score;
        private string _name;
        private static Random _random=new Random();
        public Player(string name)
        {
            _name = name;
        }
        public void Gamble()
        {
            for (int i = 0; i < 5; i++)
            {
                int roll = _random.Next(1, 7);
                Console.WriteLine($"{_name} würfelt: {roll}");
                _score += roll;
            }
        }
        public int GetScore()
        {
            return _score;
        }
        public string GetName()
        {
            return _name;
        }
    }
}
