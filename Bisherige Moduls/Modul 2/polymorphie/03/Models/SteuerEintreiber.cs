using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Models
{
    internal class SteuerEintreiber : Einwohner
    {
        private Adel _adel;
        private König _könig;
        private Bürger _bürger;
        private Leibeigenen _leibeigenen;
        public SteuerEintreiber(int einkommen,Adel adel , König könig ,Bürger bürger, Leibeigenen leibeigenen):base(einkommen=0) 
        {
            _adel = adel;
            _könig=könig ;
            _bürger=bürger ;
            _leibeigenen=leibeigenen ;
        }
        public int GetGesamtSteuer()
        {
            return
            _bürger.BerechneSteuern()+
            _adel.BerechneSteuern()+
            _könig.BerechneSteuern()+
            _leibeigenen.BerechneSteuern();
        }
    }
}