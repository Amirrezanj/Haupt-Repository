using TodoAppMaui.ViewModels;

namespace TodoAppMaui.Views;

public partial class TodoPage : ContentPage
{
    private readonly TodoViewModles _todoViewModles;
    public TodoPage(TodoViewModles todoViewModles)
    {
        BindingContext = todoViewModles;
        InitializeComponent();
        _todoViewModles = todoViewModles;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///LoginPage");
    }
}
