namespace _02.Models
{
    internal class Katze : Haustier
    {
        private Vogel _lieblingsvogel;
        public Katze(string name,int jahreskosten,Vogel lieblingsvogel):base(name,false,jahreskosten)
        {
            _lieblingsvogel = lieblingsvogel;
        }
        public string GetVogelname()
        {
            return _lieblingsvogel.GetName();
        }
        public override string GetBeschreibung()
        {
            return $"{base.GetBeschreibung()} und seine lieblings vogel ist {_lieblingsvogel.GetName()}";
        }
        public void SetLieblingsvogel(Vogel lieblingsvogel)
        {
            _lieblingsvogel=lieblingsvogel;
        }
    }
}
