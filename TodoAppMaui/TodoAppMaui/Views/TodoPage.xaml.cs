using TodoAppMaui.ViewModels;

namespace TodoAppMaui.Views;

public partial class TodoPage : ContentPage
{
    public TodoPage(TodoViewModles todoViewModles)
    {
        BindingContext = todoViewModles;
        InitializeComponent();
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///LoginPage");
    }
}
