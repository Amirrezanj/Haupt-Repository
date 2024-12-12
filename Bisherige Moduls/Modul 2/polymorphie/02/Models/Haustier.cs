namespace _02.Models
{
    public abstract class Haustier
    {
        private string _name;
        private bool _steuerpflicht;
        private int _jahreskosten;


        public string GetName()
        {
            return _name;
        }
        public bool GetSteuerpflicht()
        {
            return _steuerpflicht;
        }
        public int GetJahresKosten()
        {
            return _jahreskosten ;
        }
        public Haustier(string name,bool steuerpflicht,int jahreskosten)
        {
            _name = name;
            _jahreskosten = jahreskosten;
            _steuerpflicht=steuerpflicht;
        }
        public virtual string GetBeschreibung()
        {
            if (_steuerpflicht)
            {
                return $"{_name} ist steuerpflicht";
            }
            else 
            {
                return $"{_name} ist nicht steuerpflicht";
            }
        }
    }
}
