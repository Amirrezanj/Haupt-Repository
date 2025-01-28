using TodoAppMaui.Abstractions;
using TodoAppMaui.Models;
using TodoAppMaui.ViewModels;

namespace TodoAppMaui.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModels viewModels)
        {

            BindingContext = viewModels;

            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///LoginPage");
        }
    }
}