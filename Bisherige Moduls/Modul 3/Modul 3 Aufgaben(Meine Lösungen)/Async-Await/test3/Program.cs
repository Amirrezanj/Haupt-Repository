namespace test3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");

            var task1 = RunTaskAsync(1);
            var task2 = RunTaskAsync(2);
            var task3 = RunTaskAsync(3);

            try
            {
                await Task.WhenAll(task1, task2, task3);
                Console.WriteLine("Alle Aufgaben erfolgreich abgeschlossen!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }

            Console.ReadLine();
        }

        static async Task RunTaskAsync(int taskNumber)
        {
            Console.WriteLine($"Aufgabe {taskNumber} gestartet.");

            if (taskNumber == 2)
            {
                throw new Exception($"Fehler in Aufgabe {taskNumber}");
            }

            await Task.Delay(2000); // Simuliert eine Verzögerung
            Console.WriteLine($"Aufgabe {taskNumber} abgeschlossen.");
        }
    }
}
