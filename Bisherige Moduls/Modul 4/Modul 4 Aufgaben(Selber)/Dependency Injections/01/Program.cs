using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollections= new ServiceCollection();
            serviceCollections.AddTransient<IDatabaseService,DatabaseService>();
            serviceCollections.AddLogging(x =>
            {
                x.AddDebug();
                x.AddConsole();
                x.AddEventLog();

                x.SetMinimumLevel(LogLevel.Trace);
            });
            var Provider = serviceCollections.BuildServiceProvider();
            var dataservice = Provider.GetRequiredService<IDatabaseService>();
            dataservice.DoSomthing();
        }
        public interface IDatabaseService
        {
            void DoSomthing();
        }

        public class DatabaseService : IDatabaseService
        {
            private readonly ILogger<DatabaseService> _logger;
            public DatabaseService(ILogger<DatabaseService> logger)
            {
                _logger = logger;
            }
            public void DoSomthing()
            {
                _logger.LogInformation("hi du");
                _logger.LogCritical("DatenBank is am Arch");
                _logger.LogDebug("Debug test");
            }

        }
    }
}