namespace _03.Models
{
    public class Leibeigenen : Einwohner
    {
        public Leibeigenen (int einkommen) : base(einkommen)
        {
        }
        public override int GetZuVersteuerndesEinkommen()
        {
            return _einkommen - 12;
        }
    }
}
