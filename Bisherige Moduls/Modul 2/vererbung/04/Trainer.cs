using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    public class Trainer
    {
        private string _name;
        private int _alter;
        private int _erfahrung;

        public Trainer(string name, int alter, int erfahrung)
        {
            _name = name;
            _alter = alter;
            _erfahrung = erfahrung;
        }

        public string GetName()
        {
            return _name;
        }
        public int GetAlter()
        {
            return _alter;
        }

        public int Geterfahrung()
        {
            return _erfahrung;
        }
        
    }

}
