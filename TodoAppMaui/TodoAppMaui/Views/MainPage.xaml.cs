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

       
    }
}