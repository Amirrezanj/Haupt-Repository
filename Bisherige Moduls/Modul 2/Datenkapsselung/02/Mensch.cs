namespace _02
{
    internal class Mensch
    {
        private string _name = string.Empty;
        private int _alter;

        public string Vorstellen()
        {
            return $"hi ich bin {_name} und {_alter} jahre alt";
        }

        public string Geburstag()
        {
            _alter += 1;
            return($"du bist jetzt {_alter}");
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public void SetAlter(int alter)
        {
            _alter = alter;
        }
    }
}