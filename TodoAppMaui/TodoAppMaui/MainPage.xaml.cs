using TodoAppMaui.Abstractions;
using TodoAppMaui.Models;

namespace TodoAppMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly IDataService _dataService;

        public MainPage(IDataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
        }

        private async void Register(object? sender, EventArgs e)
        {
            var address = new CreateAddressRequest(
                "Peterweg",
                "12",
                "12123",
                "awdeawd",
                "awdawd");
            var request = new CreateUserRequest(
                "amir",
                _secondNameEntry.Text,
                _lastNameEntry.Text,
                _emailEntry.Text,
                _passwordEntity.Text,
                address
                );

            await _dataService.CreateUserAsync(request);
        }
    }
}