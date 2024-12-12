namespace _03.Models
{
    public abstract class Einwohner
    {
        protected int _einkommen;
        public Einwohner(int einkommen)
        {
            _einkommen = einkommen;
        }
        public virtual int BerechneSteuern()
        {
            if (GetZuVersteuerndesEinkommen() * 10 / 100 < 1)
            {
                return 1;
            }
            return (GetZuVersteuerndesEinkommen()*10/100);
        }
        public virtual int GetZuVersteuerndesEinkommen()
        {
            return _einkommen;
        }
        public double GetEinkommen()
        {
            return _einkommen;
        }
    }
}
