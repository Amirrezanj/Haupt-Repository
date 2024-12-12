u

namespace _04
{
    public class Torwart : Spieler
    {
        private int reaktion;

        public Torwart(string name, int alter, int stärke, int torschuss, int motivation, int reaktion)
            : base(name, alter, stärke, torschuss, motivation)
        {
            this.reaktion = reaktion;
        }

        public int GetReaktion() => reaktion;

        public bool HältDenSchuss(int schussQualität)
        {
            Random random = new Random();
            int halteQualität = Math.Max(1, Math.Min(10, reaktion + random.Next(3) - 1));
            return halteQualität >= schussQualität;
        }
    }

}
