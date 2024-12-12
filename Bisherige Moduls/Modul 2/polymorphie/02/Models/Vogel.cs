namespace _02.Models
{
    internal class Vogel : Haustier
    {
        private string _singvogel;
        public Vogel(string name ,int jahreskosten,string singvogel) : base(name,false,jahreskosten)
        {
            _singvogel = singvogel;
        }
        public string GetSingvogel()
        {
            return _singvogel;
        }
        public override string GetBeschreibung()
        {
            return $"{base.GetBeschreibung()} und kann auch {_singvogel} singen";
        }
    }
}