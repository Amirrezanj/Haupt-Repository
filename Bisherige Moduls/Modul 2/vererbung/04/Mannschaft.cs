using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    public class Mannschaft
    {
        private string _name;
        private Trainer _trainer;
        private Torwart _torwart;
        private Spieler[] _spieler;

        public Mannschaft(string name, Trainer trainer, Torwart torwart, Spieler[] spieler)
        {
            _name = name;
            _trainer = trainer;
            _torwart = torwart;
            _spieler = spieler;
        }

        public string GetName() => _name;
        public Trainer GetTrainer() => _trainer;
        public Torwart GetTorwart() => _torwart;

        public Spieler[] GetKader() => _spieler;

        public float GetStärke()
        {
            int summeStärke = 0;
            foreach (Spieler s in _spieler)
            {
                summeStärke += s.GetStärke();
            }
            return summeStärke / (float)_spieler.Length;
        }

        public float GetMotivation()
        {
            int summeMotivation = 0;
            foreach (Spieler s in _spieler)
            {
                summeMotivation += s.GetMotivation();
            }
            return summeMotivation / (float)_spieler.Length;
        }
    }

}
