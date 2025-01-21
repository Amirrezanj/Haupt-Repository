namespace TodoAppMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void ChangeThemeClicked(object? sender, EventArgs e)
        {
            if (Application.Current.UserAppTheme == AppTheme.Light)
                Application.Current.UserAppTheme = AppTheme.Dark;
            else
                Application.Current.UserAppTheme = AppTheme.Light;
        }
    }

}
