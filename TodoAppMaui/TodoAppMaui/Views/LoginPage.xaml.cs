using TodoAppMaui.ViewModels;
using TodoAppMaui.Resources.Localization;
namespace TodoAppMaui.Views;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModels _ViewModel;
	public LoginPage(LoginViewModels loginViewModels)
	{
		BindingContext = _ViewModel = loginViewModels;

        InitializeComponent();
	}
	private async void Button_Clicked(object sender ,EventArgs e)
	{
        Button button = (Button)sender;
        await button.FadeTo(0,4000);
        await button.FadeTo(1,3000);
        //await Shell.Current.GoToAsync("TodoPage");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _ViewModel.LoginFailed += LoginFailed;
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _ViewModel.LoginFailed -= LoginFailed;
    }
    private async void LoginFailed(object? sender, EventArgs e)
    {
        await DisplayAlert(AddResources.Fehler_popup, AddResources.LoginText_popup, "Ok");
    }
}
//await Shell.Current.GoToAsync("SettingsPage?Name=Paul");
