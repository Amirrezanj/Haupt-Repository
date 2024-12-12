namespace _02
{
    public class Boxer
    {
        private string _name;
        private int _vitalitaet;
        private static Random _random = new Random();

        public Boxer(string name)
        {
            _name = name;
            _vitalitaet = 10;
        }
        public Boxer(string name, int vitalität)
        {
            _name = name;
            _vitalitaet = vitalität;
        }


        public string GetName()
        {
            return _name;
        }

        public int GetVitalitaet()
        {
            return _vitalitaet;
        }

        public void Schlagen(Boxer oponent)
        {
            int rand = _random.Next(1, 3);
            if (rand == 2)
            {
                oponent._vitalitaet -= 1;
                Console.WriteLine($"{_name} trifft {oponent._name} Vitalität von {oponent._name}: {oponent._vitalitaet}");
            }
        }
    }
}