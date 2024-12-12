namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WarpKern warpKern = new WarpKern();
            WarpkernKonsole warpkernKonsole = new WarpkernKonsole(warpKern);

            warpKern.temperatur = 30;
            warpKern.temperatur = 550;
        }
    }
    public class WarpKern
    {
        private int _temperatur;
        public int temperatur
        {
            get => _temperatur;
            set
            {
                if (_temperatur != value)
                {
                    int oldtemp = _temperatur;
                    _temperatur = value;
                    TemperaturChanged?.Invoke(this, new TemperaturChangedEventArgs<int>(oldtemp, _temperatur));
                    if (_temperatur >= 500)
                    {
                        TemperaturÜber500?.Invoke(this, new TemperaturChangedEventArgs<int>(oldtemp, _temperatur));
                    }
                }
            }
        }
        public event EventHandler<TemperaturChangedEventArgs<int>>? TemperaturChanged;
        public event EventHandler<TemperaturChangedEventArgs<int>>? TemperaturÜber500;
    }
    public class WarpkernKonsole
    {
        public WarpkernKonsole( WarpKern warpKern) 
        {
            warpKern.TemperaturChanged += WarpKern_TemperaturChanged;
            warpKern.TemperaturÜber500 += WarpKern_TemperaturÜber500;
        }

        private void WarpKern_TemperaturÜber500(object? sender, TemperaturChangedEventArgs<int> e)
        {
            Console.WriteLine($"temp hat sich geändert über 500!! alte : {e.OldValue} neue : {e.NewValue} zeit : {e.Time}");
        }

        private void WarpKern_TemperaturChanged(object? sender, TemperaturChangedEventArgs<int> e)
        {
            Console.WriteLine($"temp hat sich geändert die alte wert war {e.OldValue} und neue: {e.NewValue}  zeit: {e.Time}");
        }
    }
    public class TemperaturChangedEventArgs<T> : EventArgs
    {
        public T OldValue { get; }
        public T NewValue { get; }

        public DateTime Time { get; }

        public TemperaturChangedEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
            Time = DateTime.Now;
        }
    }
}
