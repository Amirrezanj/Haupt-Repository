using Microsoft.Extensions.Logging;
using TodoAppMaui.Abstractions;
using TodoAppMaui.Services;
using TodoAppMaui.ViewModels;
using TodoAppMaui.Views;

namespace TodoAppMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Farsan-Regular.ttf", "farsan");
                });
            //neu
            builder.Services.AddSingleton<IDataService, DataService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModels>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
