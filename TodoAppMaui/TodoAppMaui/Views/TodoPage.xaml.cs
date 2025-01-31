using TodoAppMaui.ViewModels;

namespace TodoAppMaui.Views;

public partial class TodoPage : ContentPage
{
    private readonly TodoViewModles _todoViewModles;
    public TodoPage(TodoViewModles todoViewModles)
    {
        BindingContext = todoViewModles;
        InitializeComponent();
        BindingContext=_todoViewModles = todoViewModles;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SettingsPage");
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _todoViewModles.GetTodos.Execute(null);
        _todoViewModles.FailedShowTodos += FailedShowTodos;
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _todoViewModles.FailedShowTodos -= FailedShowTodos;

    }
    private async void FailedShowTodos(object? sender, EventArgs e)
    {
        await DisplayAlert("Fehler","nicht in ordnung","ok");
    }
}