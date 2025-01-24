using System.Diagnostics;

namespace TodoAppMaui.Views;
[QueryProperty("Name","Name")]
public partial class SettingsPage : ContentPage
{
	public string name { get; set; } = string.Empty;

	public string Name
	{
		get => name;
		set
		{
			name = value;
			Debug.WriteLine(name);
		}
	}
	public SettingsPage()
	{
		InitializeComponent();
	}
}