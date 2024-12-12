namespace _02.Models
{
    internal class Hund : Haustier
    {
        private string _rasse;
        public Hund(string name,int jahreskosten,string rasse):base(name,true,jahreskosten)
        {
            _rasse = rasse;
        }
        public string Getrasse()
        {
            return _rasse;
        }
        public override string GetBeschreibung()
        {
            return $"{base.GetBeschreibung()} und die rasse ist {_rasse}";
        }

    }
}
