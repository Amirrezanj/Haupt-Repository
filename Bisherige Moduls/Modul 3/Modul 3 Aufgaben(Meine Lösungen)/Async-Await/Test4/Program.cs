namespace Test4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");

            //var result1 = await PerformTaskAsync("Aufgabe 1", 5000);
            //var result2 = await PerformTaskAsync("Aufgabe 2", 2000);
            //var result3 = await PerformTaskAsync("Aufgabe 3", 1000);

            await Task.WhenAll(PerformTaskAsync("Aufgabe1", 3000), PerformTaskAsync("Aufgabe2", 2000),PerformTaskAsync("Aufgabe3", 1000));
            Console.WriteLine("finish");
            //Console.WriteLine($"Ergebnisse: {result1}, {result2}, {result3}");
            Console.ReadLine();
        }
        static async Task<string> PerformTaskAsync(string taskName, int delay)
        {
            Console.WriteLine($"{taskName} gestartet.");
            await Task.Delay(delay); // Verzögerung simulieren
            Console.WriteLine($"{taskName} abgeschlossen.");
            return $"{taskName} fertig";
        }
    }
}
