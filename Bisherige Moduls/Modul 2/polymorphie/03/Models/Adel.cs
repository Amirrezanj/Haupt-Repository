namespace _03.Models
{
    internal class Adel : Einwohner
    {
        public Adel(int einkommen):base(einkommen)
        {
        }
        public override int BerechneSteuern()
        {
            double temp = _einkommen * 0.1;
            if (temp < 20)
            {
                return 20;
            }
            return base.BerechneSteuern();
        }

    }
}