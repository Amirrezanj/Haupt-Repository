using System.Diagnostics;
using TodoAppMaui.Abstractions;
using TodoAppMaui.ViewModels;

namespace TodoAppMaui.Views;
//[QueryProperty("Name","Name")]
public partial class SettingsPage : ContentPage
{
	private readonly SettingViewModels _settingViewModels;
    private readonly IpreferenceService _preferenceService;
	//public string name { get; set; } = string.Empty;

	//public string Name
	//{
	//	get => name;
	//	set
	//	{
	//		name = value;
	//		Debug.WriteLine(name);
	//	}
	//}
	public SettingsPage(SettingViewModels viewModel, IpreferenceService preferenceService)
	{
		InitializeComponent();
		BindingContext = viewModel;
        _preferenceService = preferenceService;

	}
    

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (Application.Current.UserAppTheme == AppTheme.Light)
        {
            _preferenceService.CurrentTheme = "Dark";
            Application.Current.UserAppTheme = AppTheme.Dark;

        }
        else if (Application.Current.UserAppTheme == AppTheme.Dark)
        {
            _preferenceService.CurrentTheme = "Light";
            Application.Current.UserAppTheme = AppTheme.Light;
        }
        else
        {
            _preferenceService.CurrentTheme = "Light";
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}