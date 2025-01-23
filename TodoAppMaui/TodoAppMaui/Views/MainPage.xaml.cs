using TodoAppMaui.Abstractions;
using TodoAppMaui.Models;
using TodoAppMaui.ViewModels;

namespace TodoAppMaui.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly IDataService _dataService;

        public MainPage(IDataService dataService)
        {
            _dataService = dataService;

            BindingContext = new MainViewModels();

            InitializeComponent();
        }

        private async void Register(object? sender, EventArgs e)
        {
            var address = new CreateAddressRequest(
                _strasseEntity.Text,
                _hausNumberEntity.Text,
                _cityEntity.Text,
                _zipCodeEntity.Text,
                _countryEntry.Text);
            var request = new CreateUserRequest(
                _firstNameEntry.Text,
                _secondNameEntry.Text,
                _lastNameEntry.Text,
                _emailEntry.Text,
                _passwordEntry.Text,
                address
                );

            await _dataService.CreateUserAsync(request);
        }
    }
}