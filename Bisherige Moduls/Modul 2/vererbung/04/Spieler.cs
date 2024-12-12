using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    public class Spieler
    {
        protected string _name;
        protected int _alter;
        protected int _stärke;
        protected int _torschuss;
        protected int _motivation;
        protected int _tore;

        private static Random random = new Random();

        public Spieler(string name, int alter, int stärke, int torschuss, int motivation)
        {
            _name = name;
            _alter = alter;
            _stärke = stärke;
            _torschuss = torschuss;
            _motivation = motivation;
            _tore = 0;
        }

        public string GetName()
        {
            return _name;
        }
        public int GetAlter() => _alter;
        public int GetStärke() => _stärke;
        public int GetTorschuss() => _torschuss;
        public int GetMotivation() => _motivation;
        public int GetTore() => _tore;

        public void AddTor() => _tore++;

        public int SchiesstAufTor()
        {
            _torschuss = Math.Max(1, Math.Min(10, _torschuss - random.Next(3)));
            int schussQualität = Math.Max(1, Math.Min(10, _torschuss + random.Next(3) - 1));
            return schussQualität;
        }
    }

}
