using TodoAppMaui.Views;

namespace TodoAppMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
        }
    }
}
