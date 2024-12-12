namespace _01
{
    public class Socke
    {
        private string _farbe;
        private bool _trocken = true;
        private bool _sauber = false;


        public void Wasche()
        {
            _sauber = true;
            _trocken = false;
        }
        public void Trockene()
        {
            _trocken = true;

        }
        public string Ausgabe()
        {
            //return $"die socke mit der farbe {_farbe} ist {(_sauber ? "sauber" : "dreckig")} und {(_trocken ? "trocken" :"nass")}";
            string SauberText = _sauber ? "sauber" : "dreckig";
            string TrockenText = _trocken ? "trocken" : "nass";
            return $"Die Socke mit der Farbe {_farbe} ist {SauberText} und {TrockenText}";
        }
        public void SetFarbe(string newFarbe)
        {
            _farbe = newFarbe;
        }

    }
}