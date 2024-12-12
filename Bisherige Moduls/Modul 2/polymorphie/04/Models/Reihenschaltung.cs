namespace _04.Models
{
    public class Reihenschaltung : Wiederstandsnetzt 
    {
        public Reihenschaltung(params Wiederstand[] wiederstand) : base(wiederstands)
        {
        }
        protected override void Wiederstandsberechnung()
        {
            double summe=0;
            for (int i = 0; i < _wiederstands.Length ; i++)
            {
               summe+= _wiederstands[i].GetWiederstandswert();
            }
            _wiederstandswert = summe;
        }
        public override void ErzeugeName()
        {
            _wiederstandsname = "(R_r: "; 
            base.ErzeugeName();
        }
    }
}
