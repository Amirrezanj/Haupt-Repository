using TodoAppMaui.ViewModels;

namespace TodoAppMaui.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModels loginViewModels)
	{
		BindingContext = loginViewModels;

        InitializeComponent();
	}
	private async void Button_Clicked(object sender ,EventArgs e)
	{
        await Shell.Current.GoToAsync("TodoPage");
    }
}
//await Shell.Current.GoToAsync("SettingsPage?Name=Paul");
