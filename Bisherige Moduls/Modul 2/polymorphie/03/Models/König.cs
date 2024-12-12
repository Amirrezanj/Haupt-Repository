namespace _03.Models
{
    internal class König : Einwohner
    {
        public König(int einkommen): base(einkommen)
        {
        }
        public override int BerechneSteuern()
        {
            return 0;
        }
    }
}
