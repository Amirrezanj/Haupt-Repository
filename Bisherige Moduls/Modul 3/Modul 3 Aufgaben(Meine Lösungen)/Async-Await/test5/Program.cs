namespace test5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");

            var task1 = PerformTaskAsync(1, 2000);
            var task2 = PerformTaskAsync(2, 3000);
            var task3 = PerformTaskAsync(3, 1500);

            var completedTask = await Task.WhenAny(task1, task2, task3);
            Console.WriteLine($"Die erste abgeschlossene Aufgabe: {completedTask}");

            Console.ReadLine();
        }

        static async Task<string> PerformTaskAsync(int taskNumber, int delay)
        {
            Console.WriteLine($"Aufgabe {taskNumber} gestartet.");
            await Task.Delay(delay); // Verzögerung simulieren
            Console.WriteLine($"Aufgabe {taskNumber} abgeschlossen.");
            return $"Aufgabe {taskNumber} fertig";
        }

    }
}
