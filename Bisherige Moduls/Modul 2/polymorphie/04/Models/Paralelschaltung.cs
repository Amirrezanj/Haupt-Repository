namespace _04.Models
{
    internal class Paralelschaltung : Wiederstandsnetzt
    {
        public Paralelschaltung(params Wiederstand[]wiederstand ) : base(wiederstand)
        {
        }
        protected override void Wiederstandsberechnung()
        {
            double summe = 0;
            for (int i = 0; i < _wiederstands.Length; i++)
            {
                summe +=  (1 / _wiederstands[i].GetWiederstandswert());
            }
            _wiederstandswert= 1/summe; 
        }
        public override void ErzeugeName()
        {
            _wiederstandsname = "(R_p: ";
            base.ErzeugeName();
        }
    }
}