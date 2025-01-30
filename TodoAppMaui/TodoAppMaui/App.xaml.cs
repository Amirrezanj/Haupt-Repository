using TodoAppMaui.Abstractions;
using TodoAppMaui.Services;

namespace TodoAppMaui
{
    
    public partial class App : Application
    {
        private readonly IpreferenceService _preferences;
        public App(IpreferenceService preferences)
        {
            InitializeComponent();
            _preferences = preferences;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window= new Window(new AppShell());

          
            window.Created += (x, y) =>
            {
                window.Width= _preferences.WindowWidth;
                window.Height= _preferences.WindowHeight;
                window.X=_preferences.x;
                window.Y=_preferences.y;

                if (_preferences.CurrentTheme == "Dark")
                {
                    Application.Current.UserAppTheme = AppTheme.Dark;
                }
                else
                {
                    Application.Current.UserAppTheme = AppTheme.Light;
                }


            };

            window.Destroying += (x, y) => 
            {
                _preferences.WindowWidth= window.Width;
                _preferences.WindowHeight= window.Height;
                _preferences.x= window.X;
                _preferences.y= window.Y;
                
            };
            
           
            return window;
        }
    }
}