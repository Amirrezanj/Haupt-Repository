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
            builder.Services.AddTransient<IpreferenceService, PreferenceService>();
            builder.Services.AddTransient<ISecureStorageService, SecureStorageService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModels>();
            builder.Services.AddTransient<LoginViewModels>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<TodoPage>();
            builder.Services.AddTransient<TodoViewModles>();
            builder.Services.AddTransient<SettingViewModels>();
            builder.Services.AddTransient<SettingsPage>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
