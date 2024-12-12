namespace _04.Models
{
    public abstract class Wiederstandsnetzt : Wiederstand
    {
        protected Wiederstand[] _wiederstands;

        public Wiederstandsnetzt(Wiederstand[] wiederstands) 
        {
            _wiederstands = wiederstands;
            Wiederstandsberechnung();
            ErzeugeName();
        }

        protected abstract void Wiederstandsberechnung();

        public virtual void ErzeugeName()
        {
            for (int i = 0; i < _wiederstands.Length; i++)
            {
                _wiederstandsname += $"{_wiederstands[i].GetWiederstandsname()}";
                if (i < _wiederstands.Length - 1)
                {
                    _wiederstandsname += ",";
                }
            }_wiederstandsname += ")";
        }
    }
}